using Application.DTOs.BrandDTOs;
using Application.Features.Rules;
using Application.Models;
using Application.Repositories.BrandRepositories;
using Application.Services;
using Domain.Entities;

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
        if (!string.IsNullOrEmpty(brandName))
        {
            await _brandBusinessRules.BrandNameDuplicateControl(brandName);
            await _brandWriteRepository.AddAsync(new(brandName));
            await _brandWriteRepository.SaveAsync();
            return true;
        }
        throw new Exception("Brand name can not be null or empty!");
    }

    public async Task<bool> UpdateBrand(string brandId, string brandName)
    {
        if (string.IsNullOrEmpty(brandId) || string.IsNullOrEmpty(brandName))
            return false;

        Brand? brand = await _brandReadRepository.GetByIdAsync(Guid.Parse(brandId));
        if (brand == null || brand.BrandName == brandName)
            return false;

        brand.BrandName = brandName;
        await _brandWriteRepository.SaveAsync();
        return true;
    }

    public async Task<bool> RemoveBrand(string brandId)
    {
        if (string.IsNullOrEmpty(brandId) || !Guid.TryParse(brandId, out Guid guid))
            return false;

        Brand? brand = await _brandReadRepository.GetByIdAsync(guid);
        if (brand == null)
            return false;

        bool result = _brandWriteRepository.Remove(brand);
        await _brandWriteRepository.SaveAsync();

        return result;
    }

    public Task<bool> AddNewBrandRangeAsync(string[] brandNames)
    {
        throw new NotImplementedException();
    }

    public bool RemoveBrandRange(string[] brandNames)
    {
        throw new NotImplementedException();
    }


    public async Task<BrandListModel> GetAllBrandsAsync(int page, int pageSize)
    {
        if (page < 1 || pageSize < 1)
            throw new Exception("Invalid request! Page or page size cannot be 0 or below.");

        ICollection<Brand?> brandList = _brandReadRepository.GetAll(page, pageSize, out int totalCount, out int pageCount, out bool hasPrevious, out bool hasNext, tracking: false).ToList();
        if (brandList.Count < 1)
            throw new Exception("Invalid request or there is no brand in database.");

        return await Task.Run(() =>
        {
            BrandListModel brands = new()
            {
                Items = brandList.Select(b => new BrandListDTO() { Id = b.Id, BrandName = b.BrandName }).ToList(),
                Count = totalCount,
                PageCount = pageCount,
                HasPrevious = hasPrevious,
                HasNext = hasNext,
                Index = page,
                PageSize = pageSize
            };
            return brands;
        }
            );
    }

    public Task<Brand> GetSingleBrandAsync(string brandId)
    {
        throw new NotImplementedException();
    }
}