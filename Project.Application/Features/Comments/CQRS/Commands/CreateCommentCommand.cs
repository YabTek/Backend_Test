using Project.Application.Features.Comments.DTOs;
using Project.Application.Responses;
using MediatR;


namespace Project.Application.Features.Comment.CQRS.Commands
{
    public class CreateCommentCommand: IRequest<BaseCommandResponse>
    {
        public CreateCommentDto CreateCommentDto { get; set; }
    }
}