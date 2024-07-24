using System;
using Project.Application.Features.Common;

namespace Project.Application.Features.Recipes.DTOs
{
    public class UpdateRecipeDto : BaseDto
{
    public string Title { get; set; } 
    public string Instructions { get; set; } 
    public int PreparationTime { get; set; } 
}

}
