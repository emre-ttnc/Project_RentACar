using Application.DTOs.AuthDTOs;
using Application.Services;
using Domain.Entities.UserEntities;

namespace Persistence.Services;

public class AuthService : IAuthService
{
    public Task<AccessToken> CreateAccessTokenAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<AccessToken> LoginAsync(string email, string password)
    {
        throw new NotImplementedException();
    }

    public Task<AccessToken> RefreshAccessTokenAsync(User user)
    {
        throw new NotImplementedException();
    }
}