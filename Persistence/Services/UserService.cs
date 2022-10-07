using Application.Features.Rules;
using Application.Helpers;
using Application.Repositories.UserRepository.cs;
using Application.Services;
using Domain.Entities.UserEntities;

namespace Persistence.Services;

public class UserService : IUserService
{
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IUserWriteRepository _userWriteRepository;

    public UserService(UserBusinessRules userBusinessRules, IUserWriteRepository userWriteRepository)
    {
        _userBusinessRules = userBusinessRules;
        _userWriteRepository = userWriteRepository;
    }

    public async Task<bool> RegisterAsync(string email, string password, string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(email.Trim()) || string.IsNullOrEmpty(password.Trim()) || string.IsNullOrEmpty(firstName.Trim()) || string.IsNullOrEmpty(lastName.Trim()))
            throw new Exception("Please fill in all fields.");

        if (!await _userBusinessRules.EmailDuplicateControl(email))
            throw new Exception("There is already an account with that email address!");

        HashingHelper.CreatePasswordHash(password, out byte[] passwordSalt, out byte[] passwordHash);

        bool result = await _userWriteRepository.AddAsync(new User()
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            PasswordSalt = passwordSalt,
            PasswordHash = passwordHash,
            Status = false,
            UserClaims = new List<UserClaim>() { new UserClaim() { Claim = "Customer"} }
        });

        await _userWriteRepository.SaveAsync();
        return result;
    }
}