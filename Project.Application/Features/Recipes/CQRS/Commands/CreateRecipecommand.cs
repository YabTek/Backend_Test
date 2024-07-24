using Project.Application.Features.Recipes.DTOs;
using Project.Application.Responses;
using MediatR;


namespace Project.Application.Features.Recipes.CQRS.Commands
{
    public class CreateRecipeCommand: IRequest<BaseCommandResponse>
    {
        public CreateRecipeDto CreateRecipeDto { get; set; }
    }
}