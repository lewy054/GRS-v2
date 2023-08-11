using Grpc.Core;
using GRS.Application.ForumCommands;
using GRSForumProto;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace GRS.Application;

[Authorize]
public class ForumService : GRSForumManager.GRSForumManagerBase
{
    private readonly IMediator _mediator;

    public ForumService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<GenericResponse> CreateThread(CreateThreadRequest request, ServerCallContext context)
    {
        var authorId = context.GetUserId();
        if (!authorId.HasValue)
        {
            return new GenericResponse()
            {
                Succeeded = false,
                Error = "Wrong format of user Id"
            };
        }
        var response = await _mediator.Send(new AddThreadCommand.Request()
        {
            Title = request.Title,
            Content = request.Content,
            AuthorId = authorId.Value,
        });
        return new GenericResponse()
        {
            Succeeded = response.Succeeded,
            Error = response.Error,
        };
    }

    public override Task<GenericResponse> Comment(CommentRequest request, ServerCallContext context)
    {
        return base.Comment(request, context);
    }
}