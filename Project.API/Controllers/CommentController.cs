using Project.Application.Features.Comment.CQRS.Commands;
using Project.Application.Features.Comment.CQRS.Queries;
using Project.Application.Features.Comments.DTOs;
using Project.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Project.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CommentDto>>> Get()
        {
            var Comments_ = await _mediator.Send(new GetCommentListQuery());
            return Ok(Comments_);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> Get(int id)
        {
            var Comments_ = await _mediator.Send(new GetCommentDetailQuery { Id = id });
            return Ok(Comments_);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCommentDto createCommentDto)
        {
            var command = new CreateCommentCommand { CreateCommentDto = createCommentDto };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateCommentDto userDto)
        {
            var command = new UpdateCommentCommand { UpdateCommentDto = userDto };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCommentCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}