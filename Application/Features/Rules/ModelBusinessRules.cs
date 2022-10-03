using Application.Repositories.ModelRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Rules;

public class ModelBusinessRules
{
    private readonly IModelReadRepository _modelReadRepository;

    public ModelBusinessRules(IModelReadRepository modelReadRepository)
    {
        _modelReadRepository = modelReadRepository;
    }

    public async Task ModelDuplicateControl(string modelName, Guid brandId)
    {
        Model? model = await _modelReadRepository.Table.Include(m => m.Brand).Where(m => m.ModelName.ToLower() == modelName.ToLower() && m.BrandId == brandId).FirstOrDefaultAsync();
        if (model != null)
            throw new Exception($"There is a {modelName} in database with that brand.");
    }
}