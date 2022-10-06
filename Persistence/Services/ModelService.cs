using Application.DTOs.ModelDTOs;
using Application.Features.Rules;
using Application.Models;
using Application.Repositories.ModelRepositories;
using Application.Services;
using Domain.Entities.CarEntities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class ModelService : IModelService
{
    private readonly IModelReadRepository _modelReadRepository;
    private readonly IModelWriteRepository _modelWriteRepository;
    private readonly ModelBusinessRules _modelBusinessRules;

    public ModelService(IModelReadRepository modelReadRepository, IModelWriteRepository modelWriteRepository, ModelBusinessRules modelBusinessRules)
    {
        _modelReadRepository = modelReadRepository;
        _modelWriteRepository = modelWriteRepository;
        _modelBusinessRules = modelBusinessRules;
    }

    public async Task<bool> AddNewModelAsync(string modelName, string brandId)
    {
        if (string.IsNullOrEmpty(modelName.Trim()))
            throw new Exception("Model name cannot be null or empty");

        if (string.IsNullOrEmpty(brandId) || !Guid.TryParse(brandId, out Guid brandGuid))
            throw new Exception("Brand is null or empty or unsupported type.");

        await _modelBusinessRules.ModelDuplicateControl(modelName, brandGuid);
        bool result = await _modelWriteRepository.AddAsync(new Model() { Id = Guid.NewGuid(), ModelName = modelName, BrandId = brandGuid });
        if (result)
            await _modelWriteRepository.SaveAsync();
        return result;
    }
    public async Task<ModelListModel> GetAllAsync()
    {
        ICollection<Model> modelList = _modelReadRepository.Table.Include(m => m.Brand).AsNoTracking().ToList();
        if (modelList.Count < 1)
            throw new Exception("Invalid request or there is no model in database.");

        return await Task.Run(() =>
        {
            ModelListModel models = new()
            {
                Items = modelList.Select(m => new ModelListDTO() { Id = m.Id.ToString(), ModelName = m.ModelName, BrandName = m.Brand.BrandName }).ToList()
            };
            return models;
        });
    }
    public async Task<ModelListDTO> GetSingleModelAsync(string modelId)
    {
        if (string.IsNullOrEmpty(modelId) || !Guid.TryParse(modelId, out Guid modelGuid))
            throw new Exception("Model is null or empty or unsupported type.");

        ModelListDTO? modelDTO = await _modelReadRepository.Table
            .Where(m => m.Id == modelGuid)
            .Select(m => new ModelListDTO() { BrandName = m.Brand.BrandName, Id = modelId, ModelName = m.ModelName })
            .FirstOrDefaultAsync();
        if (modelDTO == null)
            throw new Exception("Model not found!");
        return modelDTO;
    }
    public async Task<bool> RemoveModelAsync(string modelId)
    {
        if (string.IsNullOrEmpty(modelId) || !Guid.TryParse(modelId, out Guid modelGuid))
            throw new Exception("Brand ID is null or empty or unsupported type.");

        bool result = await _modelWriteRepository.RemoveByIdAsync(modelGuid);
        await _modelWriteRepository.SaveAsync();

        return result;
    }
    public async Task<bool> UpdateModelAsync(string modelId, string modelName)
    {
        if (string.IsNullOrEmpty(modelId) || !Guid.TryParse(modelId, out Guid modelGuid))
            throw new Exception("Brand ID is null or empty or unsupported type.");

        Model? model = await _modelReadRepository.GetByIdAsync(modelGuid);
        if (model == null)
            throw new Exception("Model not found.");

        if (model.ModelName.ToLower() == modelName.ToLower()) 
            throw new Exception("The new model name cannot be the same as the old one."); //will go to business rules

        model.ModelName = modelName;
        await _modelWriteRepository.SaveAsync();
        return true;
    }
}