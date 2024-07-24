using System;
using Project.Application.Features.Comments.DTOs;

namespace Project.Application.Features.Recipes.DTOs
{
public class IngredientDto
{
    public string Name { get; set; } 
    public string Quantity { get; set; } 
}
public class IRecipeDto
{
    public string Title { get; set; } 
    public List<IngredientDto> Ingredients { get; set; } 
    public string Instructions { get; set; } 
    public int PreparationTime { get; set; } 
    public int UserId { get; set; } 
    public ICollection<CommentDto> Comments { get; set; } 
}


}