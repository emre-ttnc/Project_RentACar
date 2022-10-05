namespace Domain.Entities.UserEntities;

public class EmailAuthenticator : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }
    public User User { get; set; } = new();

    public EmailAuthenticator()
    {
    }

    public EmailAuthenticator(string userId, string? activationKey, bool ısVerified, User user)
    {
        UserId = userId;
        ActivationKey = activationKey;
        IsVerified = ısVerified;
        User = user;
    }
}