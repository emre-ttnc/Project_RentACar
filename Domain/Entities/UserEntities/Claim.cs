namespace Domain.Entities.UserEntities;

public class Claim : BaseEntity
{
    public string ClaimName { get; set; } = string.Empty;
    public Claim() { }
    public Claim(string claimName)
    {
        ClaimName = claimName;
    }
}