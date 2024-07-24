using MediatR;


namespace Project.Application.Features.Users_.CQRS.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}