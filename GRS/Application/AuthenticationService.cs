using Grpc.Core;
using GRS.Infrastructure;
using GRS.Model.User;
using GRSAccountProto;
using Microsoft.EntityFrameworkCore;

namespace GRS.Application;

public class AuthenticationService : Authentication.AuthenticationBase
{
    private readonly JwtAuthenticationManager _jwtAuthenticationManager;
    private readonly ApplicationDbContext _context;

    public AuthenticationService(JwtAuthenticationManager jwtAuthenticationManager, ApplicationDbContext context)
    {
        _jwtAuthenticationManager = jwtAuthenticationManager;
        _context = context;
    }

    public override async Task<AuthenticationResponse> Login(LoginRequest request, ServerCallContext context)
    {
        var user = await _context.Users.FirstOrDefaultAsync(e => e.UserName == request.UserName,
            context.CancellationToken);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return new AuthenticationResponse()
            {
                Status = false,
            };
        }

        var (token, expiresIn) = _jwtAuthenticationManager.GenerateToken(user.UserName, user.Roles);
        return new AuthenticationResponse()
        {
            Status = true,
            Token = token,
            ExpiresIn = expiresIn,
        };
    }

    public override async Task<GenericResponse> Register(RegisterRequest request, ServerCallContext context)
    {
        var nameOccupation = await _context.Users
            .FirstOrDefaultAsync(e => e.UserName == request.Login, context.CancellationToken);
        if (nameOccupation != null)
        {
            return new GenericResponse()
            {
                Status = false,
                Error = "Name already taken"
            };
        }

        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password, 14);
        await _context.Users.AddAsync(new User(request.Login, passwordHash, request.Email), context.CancellationToken);
        await _context.SaveChangesAsync(context.CancellationToken);
        return new GenericResponse()
        {
            Status = true,
        };
    }
}