using Project.Application.Features.Users_.CQRS.Commands;
using Project.Application.Features.Users_.CQRS.Queries;
using Project.Application.Features.Users_.DTOs;
using Project.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Project.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            var users = await _mediator.Send(new GetUserListQuery());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(int id)
        {
            var users = await _mediator.Send(new GetUserDetailQuery { Id = id });
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateUserDto create_UserDto)
        {
            var command = new CreateUserCommand { CreateUserDto = create_UserDto };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateUserDto userDto)
        {
            var command = new UpdateUserCommand { UpdateUserDto = userDto };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteUserCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}