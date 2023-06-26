using System.Security.Claims;
using Grpc.Core;

namespace GRS;

public static class ServerCallContextExtension
{
    public static string? GetUsername(this ServerCallContext context)
    {
        var claims = context.GetHttpContext().User.Claims.ToList();
        var username = claims.FirstOrDefault(e => e.Type == "username")?.Value;
        return username;
    }
    
    public static IEnumerable<Claim> GetUserRoles(this ServerCallContext context)
    {
        var claims = context.GetHttpContext().User.Claims.ToList();
        var roles = claims.Where(e => e.Type == ClaimTypes.Role).ToList();
        return roles;
    }
}