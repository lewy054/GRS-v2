using Grpc.Core;
using GRSAccountProto;

namespace GRS.Application;

public class AuthenticationService : Authentication.AuthenticationBase
{
    public override Task<AuthenticationResponse> Authenticate(AuthenticationRequest request, ServerCallContext context)
    {
        var authenticationResponse = JwtAuthenticationManager.Authenticate(request);
        if (authenticationResponse == null)
            throw new RpcException(new Status(StatusCode.Unauthenticated, "Invalid user Credentials"));

        return Task.FromResult(authenticationResponse);
    }
}