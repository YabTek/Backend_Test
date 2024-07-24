using Project.Application.Features.Users_.DTOs;
using Project.Application.Responses;
using MediatR;


namespace Project.Application.Features.Users_.CQRS.Commands
{
    public class CreateUserCommand: IRequest<BaseCommandResponse>
    {
        public CreateUserDto CreateUserDto { get; set; }
    }
}