namespace Application.Services;

public interface IUserService
{
    Task<bool> RegisterAsync(string email, string password, string firstName, string lastName);
}