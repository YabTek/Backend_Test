using System;
using Project.Domain;
using Project.Application.Features.Recipes.DTOs;
using Project.Application.Features.Common;

namespace Project.Application.Features.Recipes.DTOs
{

    public class RecipeDto : BaseDto
    {
        public string Title { get; set; } 
        public string Instructions { get; set; } 
        public int PreparationTime { get; set; } 
        public int UserId { get; set; } 
        public User User { get; set; } 
        public ICollection<Project.Domain.Comment> Comments { get; set; } 
    }
}
