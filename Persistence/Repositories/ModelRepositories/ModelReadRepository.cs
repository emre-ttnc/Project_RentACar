using Application.Repositories.ModelRepositories;
using Domain.Entities.CarEntities;
using Persistence.Contexts;

namespace Persistence.Repositories.ModelRepositories
{
    public class ModelReadRepository : ReadRepository<Model>, IModelReadRepository 
    {
        public ModelReadRepository(RentACarDbContext context) : base(context)
        {
        }
    }
}