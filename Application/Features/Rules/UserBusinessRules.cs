using Application.Repositories.UserRepository.cs;
using Domain.Entities.UserEntities;

namespace Application.Features.Rules;

public class UserBusinessRules
{
    private readonly IUserReadRepository _userReadRepository;

    public UserBusinessRules(IUserReadRepository userReadRepository)
    {
        _userReadRepository = userReadRepository;
    }

    public async Task<bool> EmailDuplicateControl(string email)
    {
        User? user = await _userReadRepository.GetSingleAsync(user => user.Email == email);

        if(user == null)
            return true; //If there is no user with that email.

        return false;
    }
}