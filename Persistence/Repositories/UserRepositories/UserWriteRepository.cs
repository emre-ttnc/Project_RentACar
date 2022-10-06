using Application.Repositories.UserRepository.cs;
using Domain.Entities.UserEntities;
using Persistence.Contexts;

namespace Persistence.Repositories.UserRepositories;

public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
{
    public UserWriteRepository(RentACarDbContext context) : base(context)
    {
    }
}