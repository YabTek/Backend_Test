using Project.Application.Features.Comments.DTOs;
using MediatR;


namespace Project.Application.Features.Comment.CQRS.Commands
{
    public class UpdateCommentCommand : IRequest<Unit>
    {
        public UpdateCommentDto UpdateCommentDto { get; set; }

    }
}