using Project.Application.Features.Recipes.DTOs;
using MediatR;


namespace Project.Application.Features.Recipes.CQRS.Commands
{
    public class UpdateRecipeCommand : IRequest<Unit>
    {
        public UpdateRecipeDto UpdateRecipeDto { get; set; }

    }
}