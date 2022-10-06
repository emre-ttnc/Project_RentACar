using Application.Repositories.UserRepository.cs;
using Domain.Entities.UserEntities;
using Persistence.Contexts;

namespace Persistence.Repositories.UserRepositories;

public class UserReadRepository : ReadRepository<User>, IUserReadRepository
{
    public UserReadRepository(RentACarDbContext context) : base(context)
    {
    }
}