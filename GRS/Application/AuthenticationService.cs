using Grpc.Core;
using GRS.Application.AuthenticationCommands;
using GRSAccountProto;
using MediatR;

namespace GRS.Application;

public class AuthenticationService : GRSAccountProto.Authentication.AuthenticationBase
{
    private readonly IMediator _mediator;

    public AuthenticationService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<AuthenticationResponse> Login(LoginRequest request, ServerCallContext context)
    {
        var response = await _mediator.Send(new LoginUserCommand.Request()
        {
            UserName = request.UserName,
            Password = request.Password
        });

        return new AuthenticationResponse()
        {
            Status = response.Succeeded,
            Token = response.Token,
            ExpiresIn = response.ExpiresIn,
        };
    }

    public override async Task<GenericResponse> Register(RegisterRequest request, ServerCallContext context)
    {
        var response = await _mediator.Send(new RegisterUserCommand.Request()
        {
            UserName = request.Login,
            Email = request.Email,
            Password = request.Password,
        });

        return new GenericResponse()
        {
            Status = response.Succeeded,
            Error = response.Error,
        };
    }
}