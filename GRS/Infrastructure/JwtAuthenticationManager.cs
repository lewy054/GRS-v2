using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GRS.Model;
using GRS.Model.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GRS.Infrastructure;

public class JwtAuthenticationManager
{
    private readonly JwtSettings _jwtSettings;

    public JwtAuthenticationManager(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public (string, int) GenerateToken(string userid, string username, List<Role> roles)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var tokenExpiryDateTime = DateTime.Now.AddMinutes(_jwtSettings.Validity);
        var claims = new List<Claim>
        {
            new("userid", userid),
            new("username", username),
        };
        roles.ForEach(e => claims.Add(new Claim(ClaimTypes.Role, e.Name)));
        var token = new JwtSecurityToken(_jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: tokenExpiryDateTime,
            signingCredentials: credentials);
        var writeToken = new JwtSecurityTokenHandler().WriteToken(token);


        return (writeToken, (int)tokenExpiryDateTime.Subtract(DateTime.Now).TotalSeconds);
    }
}