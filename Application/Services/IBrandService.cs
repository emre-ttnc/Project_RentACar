using Application.Models;
using Domain.Entities.CarEntities;

namespace Application.Services;

public interface IBrandService
{
    #region Commands
    Task<bool> AddNewBrandAsync(string brandName);
    Task<bool> AddNewBrandRangeAsync(string[] brandNames);
    Task<bool> UpdateBrand(string brandId,string brandName);
    Task<bool> RemoveBrand(string brandId);
    Task<bool> RemoveBrandRange(string[] brandIds);
    #endregion

    #region Queries
    Task<BrandListModel> GetAll();
    Task<Brand> GetSingleBrandAsync(string brandId);
    #endregion
}