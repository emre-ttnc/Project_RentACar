using Application.DTOs.BrandDTOs;
using Application.DTOs.ModelDTOs;
using Application.DynamicQuery;
using Application.Features.Rules;
using Application.Models;
using Application.Repositories.BrandRepositories;
using Application.Services;
using Domain.Entities.CarEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Persistence.Services;

public class BrandService : IBrandService
{
    private readonly BrandBusinessRules _brandBusinessRules;
    private readonly IBrandWriteRepository _brandWriteRepository;
    private readonly IBrandReadRepository _brandReadRepository;

    public BrandService(BrandBusinessRules brandBusinessRules, IBrandWriteRepository brandWriteRepository, IBrandReadRepository brandReadRepository)
    {
        _brandBusinessRules = brandBusinessRules;
        _brandWriteRepository = brandWriteRepository;
        _brandReadRepository = brandReadRepository;
    }

    public async Task<bool> AddNewBrandAsync(string brandName)
    {
        if (!string.IsNullOrEmpty(brandName.Trim()))
        {
            await _brandBusinessRules.BrandNameDuplicateControl(brandName);
            await _brandWriteRepository.AddAsync(new() { Id = Guid.NewGuid(), BrandName = brandName });
            await _brandWriteRepository.SaveAsync();
            return true;
        }
        throw new Exception("Brand name can not be null or empty!");
    }

    public async Task<bool> UpdateBrand(string brandId, string brandName)
    {
        if (string.IsNullOrEmpty(brandId) || string.IsNullOrEmpty(brandName))
            throw new Exception("Brand ID or new brand name cannot be null or empty");

        Brand? brand = await _brandReadRepository.GetByIdAsync(Guid.Parse(brandId));
        if (brand == null) throw new Exception("Brand not found in database!");
        if (brand.BrandName == brandName) throw new Exception("The new brand name cannot be the same as the old one."); //will go to business rules

        brand.BrandName = brandName;
        await _brandWriteRepository.SaveAsync();
        return true;
    }

    public async Task<bool> RemoveBrand(string brandId)
    {
        if (string.IsNullOrEmpty(brandId) || !Guid.TryParse(brandId, out Guid guid))
            throw new Exception("ID is null or empty or unsupported id type");

        Brand? brand = await _brandReadRepository.GetByIdAsync(guid);
        if (brand == null)
            throw new Exception("Brand not found!");

        bool result = _brandWriteRepository.Remove(brand);
        await _brandWriteRepository.SaveAsync();

        return result;
    }

    public async Task<bool> AddNewBrandRangeAsync(string[] brandNames)
    {
        foreach (string brandName in brandNames)
            await AddNewBrandAsync(brandName);
        return true;
    }

    public async Task<bool> RemoveBrandRange(string[] brandIds)
    {
        foreach (string brandId in brandIds)
            await RemoveBrand(brandId);
        return true;
    }

    public async Task<BrandListModel> GetAll()
    {
        ICollection<Brand?> brandList = _brandReadRepository.GetAll(tracking: false).ToList();
        if (brandList.Count < 1)
            return new();

        return await Task.Run(() =>
        {
            BrandListModel brands = new()
            {
                Items = brandList.Select(b => new BrandListDTO() { Id = b.Id.ToString(), BrandName = b.BrandName }).ToList()
            };
            return brands;
        }
            );
    }

    public async Task<BrandListPageableModel> GetAllByDynamic(Dynamic dynamic, int page, int size, Func<IQueryable<Brand>, IIncludableQueryable<Brand, object>>? include = null)
    {
        ICollection<Brand?> brandList = await _brandReadRepository.GetAllWithDynamic(dynamic, page, size, out int totalCount, out int PageCount, out bool hasPrevious, out bool hasNext, tracking: false, include: include).ToListAsync();
        if (brandList.Count < 1)
            return new();
        return await Task.Run(() =>
        {
            BrandListPageableModel brands = new() { 
                Items = brandList.Select(b => new BrandListDTO() { Id = b.Id.ToString(), BrandName = b.BrandName, Models = b.Models.Select(
                    m => new ModelListDTO(){ Id = m.Id.ToString(), ModelName = m.ModelName, BrandName = m.Brand.BrandName }
                    ).ToList() }).ToList(),
                Count = totalCount,
                HasPrevious = hasPrevious,
                HasNext = hasNext,
                PageCount = PageCount,
                PageSize = size,
                Index = page
            };
            return brands;
        });
    }

    public Task<Brand> GetSingleBrandAsync(string brandId)
    {
        throw new NotImplementedException();
    }
}