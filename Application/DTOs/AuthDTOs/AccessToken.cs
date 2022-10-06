namespace Application.DTOs.AuthDTOs;

public class AccessToken
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpirationTime { get; set; }

    public AccessToken()
    {
    }

    public AccessToken(string token, DateTime expirationTime)
    {
        Token = token;
        ExpirationTime = expirationTime;
    }
}