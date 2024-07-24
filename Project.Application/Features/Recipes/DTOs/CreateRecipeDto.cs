using System;
using Project.Application.Features.Recipes.DTOs;

namespace Project.Application.Features.Recipes.DTOs
{
    public class CreateRecipeDto
{
    public string Title { get; set; } 
    public string Instructions { get; set; } 
    public int PreparationTime { get; set; } 
}

    
}
