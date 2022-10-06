using Application.DTOs.AuthDTOs;
using Domain.Entities.UserEntities;

namespace Application.Services;

public interface IAuthService
{
    Task<AccessToken> CreateAccessTokenAsync(User user);
    Task<AccessToken> RefreshAccessTokenAsync(User user);
    Task<AccessToken> LoginAsync(string email, string password);
}