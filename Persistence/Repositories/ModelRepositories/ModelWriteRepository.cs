using Application.Repositories.ModelRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.ModelRepositories;

public class ModelWriteRepository : WriteRepository<Model>, IModelWriteRepository
{
    public ModelWriteRepository(RentACarDbContext context) : base(context)
    {
    }
}