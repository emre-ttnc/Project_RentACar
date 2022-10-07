namespace Domain.Entities.UserEntities;

public class UserClaim : BaseEntity
{
    public Guid UserId { get; set; } = Guid.NewGuid();

    public User User { get; set; } = new();
    public string Claim { get; set; } = string.Empty;

    public UserClaim()
    {
    }

    public UserClaim(Guid userId, Guid claimId, User user, string claim)
    {
        UserId = userId;
        User = user;
        Claim = claim;
    }
}