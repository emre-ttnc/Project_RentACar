using Application.Repositories.UserRepository.cs;
using Domain.Entities.UserEntities;
using Persistence.Contexts;

namespace Persistence.Repositories.UserRepositories;

public class UserClaimReadRepository : ReadRepository<UserClaim>, IUserClaimReadRepository
{
    public UserClaimReadRepository(RentACarDbContext context) : base(context)
    {
    }
}