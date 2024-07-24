using Project.Application.Features.Users_.DTOs;
using MediatR;


namespace Project.Application.Features.Users_.CQRS.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public UpdateUserDto UpdateUserDto { get; set; }

    }
}