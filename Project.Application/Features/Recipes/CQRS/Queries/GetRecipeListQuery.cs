using Project.Application.Features.Recipes.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Application.Features.Recipes.CQRS.Queries
{
    public class GetRecipeListQuery: IRequest<List<RecipeDto>>
    {
    }
}