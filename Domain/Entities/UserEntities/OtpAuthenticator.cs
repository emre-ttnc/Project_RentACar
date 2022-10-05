namespace Domain.Entities.UserEntities;

public class OtpAuthenticator : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public byte[] SecretKey { get; set; } = Array.Empty<byte>();
    public bool IsVerified { get; set; }
    public User User { get; set; } = new();

    public OtpAuthenticator()
    {
    }

    public OtpAuthenticator(string userId, byte[] secretKey, bool ısVerified, User user)
    {
        UserId = userId;
        SecretKey = secretKey;
        IsVerified = ısVerified;
        User = user;
    }
}