using Application.Repositories.BrandRepositories;
using Domain.Entities.CarEntities;

namespace Application.Features.Rules;

public class BrandBusinessRules
{
    private readonly IBrandReadRepository _brandReadRepository;

    public BrandBusinessRules(IBrandReadRepository brandReadRepository)
    {
        _brandReadRepository = brandReadRepository;
    }

    public async Task BrandNameDuplicateControl(string brandName)
    {
        Brand? brand = await _brandReadRepository.GetSingleAsync(brand => brand.BrandName.ToLower() == brandName.ToLower());
        if (brand != null)
            throw new Exception($"There is already {brandName} in database.");
    }
}