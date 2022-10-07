using Application.DTOs.AuthDTOs;
using Application.Helpers;
using Application.Repositories.UserRepository.cs;
using Application.Services;
using Domain.Entities.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services;

public class AuthService : IAuthService
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly JWTTokenHelper _jwtTokenHelper;

    public AuthService(IUserReadRepository userReadRepository, JWTTokenHelper jwtTokenHelper)
    {
        _userReadRepository = userReadRepository;
        _jwtTokenHelper = jwtTokenHelper;
    }

    public async Task<AccessToken> LoginAsync(string email, string password)
    {
        User? user = await _userReadRepository.Table.Include(user => user.UserClaims).FirstOrDefaultAsync(user => user.Email == email);
        if (user == null) throw new Exception("Email or password is wrong!");

        bool result = HashingHelper.VerifyPasswordHash(password: password, passwordSalt: user.PasswordSalt, passwordHash: user.PasswordHash);
        if (!result) throw new Exception("Email or password is wrong!");

        if (user.UserClaims.Count < 1) throw new Exception("User roles not found.");

        return _jwtTokenHelper.CreateAccessToken(user, user.UserClaims);
    }

    public Task<AccessToken> RefreshAccessTokenAsync(User user)
    {
        throw new NotImplementedException();
    }
}