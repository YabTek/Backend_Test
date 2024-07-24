using Project.Application.Features.Recipes.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Application.Features.Recipes.CQRS.Queries
{
    public class GetRecipeDetailQuery : IRequest<RecipeDto>
    {
        public int Id { get; set; }
    }
}