namespace Domain.Entities.UserEntities;

public class UserClaim : BaseEntity
{
    public Guid UserId { get; set; } = Guid.NewGuid();
    public Guid ClaimId { get; set; } = Guid.NewGuid();

    public User User { get; set; } = new();
    public Claim Claim { get; set; } = new();

    public UserClaim()
    {
    }

    public UserClaim(Guid userId, Guid claimId, User user, Claim claim)
    {
        UserId = userId;
        ClaimId = claimId;
        User = user;
        Claim = claim;
    }
}