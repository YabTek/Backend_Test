using MediatR;


namespace Project.Application.Features.Comment.CQRS.Commands
{
    public class DeleteCommentCommand : IRequest
    {
        public int Id { get; set; }
    }
}