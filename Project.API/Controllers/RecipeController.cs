using Project.Application.Features.Recipes.CQRS.Commands;
using Project.Application.Features.Recipes.CQRS.Queries;
using Project.Application.Features.Recipes.DTOs;
using Project.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Project.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecipeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<RecipeDto>>> Get()
        {
            var Recipes = await _mediator.Send(new GetRecipeListQuery());
            return Ok(Recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDto>> Get(int id)
        {
            var Recipes = await _mediator.Send(new GetRecipeDetailQuery { Id = id });
            return Ok(Recipes);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateRecipeDto createRecipeDto)
        {
            var recipe = new CreateRecipeCommand { CreateRecipeDto = createRecipeDto };
            var repsonse = await _mediator.Send(recipe);
            return Ok(repsonse);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateRecipeDto userDto)
        {
            var recipe = new UpdateRecipeCommand { UpdateRecipeDto = userDto };
            await _mediator.Send(recipe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var recipe = new DeleteRecipeCommand { Id = id };
            await _mediator.Send(recipe);
            return NoContent();
        }
    }
}