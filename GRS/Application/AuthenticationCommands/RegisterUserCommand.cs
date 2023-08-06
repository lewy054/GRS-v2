using System.Net.Mail;
using GRS.Model.User;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GRS.Application.AuthenticationCommands;

public static class RegisterUserCommand
{
    public class Request : IRequest<Response>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly ApplicationDbContext _context;

        public Handler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var nameOccupation = await _context.Users
                .FirstOrDefaultAsync(e => e.UserName == request.UserName, cancellationToken);
            if (nameOccupation != null)
            {
                return new Response()
                {
                    Succeeded = false,
                    Error = "Name already taken"
                };
            }

            try
            {
                var _ = new MailAddress(request.Email);
            }
            catch
            {
                return new Response()
                {
                    Succeeded = false,
                    Error = "Invalid email"
                };
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password, 14);
            await _context.Users.AddAsync(new User(request.UserName, passwordHash, request.Email), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return new Response();
        }
    }

    public class Response
    {
        public bool Succeeded { get; init; } = true;
        public string Error { get; init; } = string.Empty;
    }
}