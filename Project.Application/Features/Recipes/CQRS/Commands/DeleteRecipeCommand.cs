using MediatR;


namespace Project.Application.Features.Recipes.CQRS.Commands
{
    public class DeleteRecipeCommand : IRequest
    {
        public int Id { get; set; }
    }
}