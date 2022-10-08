using Application.DynamicQuery;
using Application.Models;
using Domain.Entities.CarEntities;
using Microsoft.EntityFrameworkCore.Query;

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
    Task<BrandListPageableModel> GetAllByDynamic(Dynamic dynamic, int page, int size, Func<IQueryable<Brand>, IIncludableQueryable<Brand, object>>? include = null);
    Task<Brand> GetSingleBrandAsync(string brandId);
    #endregion
}