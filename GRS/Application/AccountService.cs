using System.Security.Claims;
using Google.Protobuf;
using Grpc.Core;
using GRSAccountProto;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

namespace GRS.Application;

[Authorize(Roles = "Administrator")]
public class AccountService : GRSAccountManager.GRSAccountManagerBase
{
    public override Task<GenericResponse> Login(LoginRequest request, ServerCallContext context)
    {
        var username = context.GetUsername();
        var roles = context.GetUserRoles();
        return Task.FromResult(new GenericResponse()
        {
            Status = true,
            Error = JsonConvert.SerializeObject(username)
        });
        return base.Login(request, context);
    }

    public override Task<GenericResponse> Register(RegisterRequest request, ServerCallContext context)
    {
        return base.Register(request, context);
    }
}