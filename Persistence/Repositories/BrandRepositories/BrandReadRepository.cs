using Application.Repositories.BrandRepositories;
using Domain.Entities.CarEntities;
using Persistence.Contexts;

namespace Persistence.Repositories.BrandRepositories;

public class BrandReadRepository : ReadRepository<Brand>, IBrandReadRepository
{
    public BrandReadRepository(RentACarDbContext context) : base(context)
    {
    }
}