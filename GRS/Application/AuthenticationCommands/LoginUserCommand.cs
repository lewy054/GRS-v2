using GRS.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GRS.Application.AuthenticationCommands;

public static class LoginUserCommand
{
    public class Request : IRequest<Response>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;


        public Handler(ApplicationDbContext context, JwtAuthenticationManager jwtAuthenticationManager)
        {
            _context = context;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(e => e.UserName == request.UserName,
                cancellationToken);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return new Response()
                {
                    Succeeded = false,
                };
            }

            var (token, expiresIn) = _jwtAuthenticationManager.GenerateToken(user.UserName, user.Roles);
            return new Response()
            {
                Token = token,
                ExpiresIn = expiresIn,
            };
        }
    }


    public class Response
    {
        public bool Succeeded { get; init; } = true;
        public string Token { get; init; } = string.Empty;
        public int ExpiresIn { get; init; }
    }
}