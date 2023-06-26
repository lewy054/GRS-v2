using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GRSAccountProto;
using Microsoft.IdentityModel.Tokens;

namespace GRS;

public static class JwtAuthenticationManager
{
    public const string JWT_TOKEN_KEY = "secretkey";
    private const int JWT_TOKEN_VALIDITY = 30;

    public static AuthenticationResponse? Authenticate(AuthenticationRequest authenticationRequest)
    {
        string userRole;
        switch (authenticationRequest.UserName)
        {
            case "admin" when authenticationRequest.Password == "admin":
                userRole = "Administrator";
                break;
            case "user" when authenticationRequest.Password == "user":
                userRole = "User";
                break;
            default:
                return null;
        }
        
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.ASCII.GetBytes(JWT_TOKEN_KEY);
        var tokenExpiryDateTime = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY);
        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new List<Claim>
            {
                new("username", authenticationRequest.UserName),
                new(ClaimTypes.Role, userRole)
            }),
            Expires = tokenExpiryDateTime,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        var token = jwtSecurityTokenHandler.WriteToken(securityToken);

        return new AuthenticationResponse
        {
            AccessToken = token,
            ExpiresIn = (int)tokenExpiryDateTime.Subtract(DateTime.Now).TotalSeconds
        };
        
    }
}