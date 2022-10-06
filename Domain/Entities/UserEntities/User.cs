using Domain.Enums;

namespace Domain.Entities.UserEntities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
    public byte[] PasswordHash { get; set; } = Array.Empty<byte>();
    public bool Status { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; } = 0;
    public ICollection<UserClaim> UserClaims { get; set; } = new HashSet<UserClaim>();

    public User()
    {
    }

    public User(string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash, bool status, AuthenticatorType authenticatorType, ICollection<UserClaim> userClaims)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        Status = status;
        AuthenticatorType = authenticatorType;
        UserClaims = userClaims;
    }
}