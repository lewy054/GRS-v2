using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GRS.Application.ForumCommands;

public static class AddThreadCommand
{
    public class Request : IRequest<Response>
    {
        public Guid AuthorId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
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
            var author = await _context.Users.FirstOrDefaultAsync(e => e.Id == request.AuthorId, cancellationToken);
            if (author == null)
            {
                return new Response()
                {
                    Succeeded = false,
                    Error = "Author not found"
                };
            }

            var thread = new Model.Forum.Thread()
            {
                Title = request.Title,
                Content = request.Content,
                Author = author,
            };
            await _context.Threads.AddAsync(thread, cancellationToken);
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