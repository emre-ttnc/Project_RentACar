using Application.Models;
using Domain.Entities;

namespace Application.Services;

public interface IBrandService
{
    #region Commands
    Task<bool> AddNewBrandAsync(string brandName);
    Task<bool> AddNewBrandRangeAsync(string[] brandNames);
    Task<bool> UpdateBrand(string brandId,string brandName);
    Task<bool> RemoveBrand(string brandId);
    bool RemoveBrandRange(string[] brandNames);
    #endregion

    #region Queries
    Task<BrandListModel> GetAllBrandsAsync(int pageNo, int pageSize);
    Task<Brand> GetSingleBrandAsync(string brandId);
    #endregion
}