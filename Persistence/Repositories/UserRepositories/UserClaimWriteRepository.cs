using Application.Repositories.UserRepository.cs;
using Domain.Entities.UserEntities;
using Persistence.Contexts;

namespace Persistence.Repositories.UserRepositories;

public class UserClaimWriteRepository : WriteRepository<UserClaim>, IUserClaimWriteRepository
{
    public UserClaimWriteRepository(RentACarDbContext context) : base(context)
    {
    }
}