using Application.DTOs.ModelDTOs;
using Application.Models;

namespace Application.Services;

public interface IModelService
{
    #region Commands
    Task<bool> AddNewModelAsync(string modelName, string brandId);
    Task<bool> UpdateModelAsync(string modelId, string modelName);
    Task<bool> RemoveModelAsync(string modelId);
    #endregion

    #region Queries
    Task<ModelListModel> GetAllAsync();
    Task<ModelListDTO> GetSingleModelAsync(string modelId);
    #endregion
}