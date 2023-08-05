using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GRS.Model;
using GRS.Model.User;
using GRSAccountProto;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;

namespace GRS.Infrastructure;

public class JwtAuthenticationManager
{

    private readonly JwtSettings _jwtSettings;

    public JwtAuthenticationManager(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    
    public (string, int) GenerateToken(string username, List<Role> roles)
    {
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.ASCII.GetBytes(_jwtSettings.Key);
        var tokenExpiryDateTime = DateTime.Now.AddMinutes(_jwtSettings.Validity);
        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new List<Claim>
            {
                new("username", username),
                new(ClaimTypes.Role, roles.ToString() ?? "")
            }),
            Expires = tokenExpiryDateTime,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        var token = jwtSecurityTokenHandler.WriteToken(securityToken);

        return (token, (int)tokenExpiryDateTime.Subtract(DateTime.Now).TotalSeconds);
    }
}