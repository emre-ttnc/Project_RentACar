using Application.DTOs.AuthDTOs;
using Domain.Entities.UserEntities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Helpers;

public class JWTTokenHelper
{
    public IConfiguration _configuration;
    private readonly TokenOptionsDTO _tokenOptions;
    private DateTime _accessTokenExpiration;

    public JWTTokenHelper(IConfiguration configuration)
    {
        _configuration = configuration;
        _tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptionsDTO>();
    }


    public AccessToken CreateAccessToken(User user, ICollection<UserClaim> userClaims)
    {
        _accessTokenExpiration = DateTime.UtcNow.AddMinutes(_tokenOptions.AccessTokenExpiration);
        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
        JwtSecurityToken jwtToken = CreateJwtSecuirtyToken(_tokenOptions, user, new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature), userClaims);
        JwtSecurityTokenHandler tokenHandler = new();
        string? token = tokenHandler.WriteToken(jwtToken);
        return new AccessToken { Token = token, ExpirationTime = _accessTokenExpiration };
    }


    private JwtSecurityToken CreateJwtSecuirtyToken(TokenOptionsDTO tokenOptions, User user, SigningCredentials signingCredentials, ICollection<UserClaim> userClaims)
    {
        return new JwtSecurityToken(
            audience: tokenOptions.Audience,
            issuer: tokenOptions.Issuer,
            expires: _accessTokenExpiration,
            notBefore: DateTime.UtcNow,
            claims: SetClaims(user, userClaims),
            signingCredentials: signingCredentials
            );
    }

    private IEnumerable<Claim> SetClaims(User user, ICollection<UserClaim> userClaims)
    {
        ICollection<Claim> claims = new HashSet<Claim>();
        claims.Add(new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Name, $"{user.FirstName} {user.LastName}"));
        userClaims.ToList().ForEach(claim => claims.Add(new Claim(type: "role", value: claim.Claim)));
        return claims;
    }
}