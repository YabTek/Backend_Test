using System.Collections.Generic;
using Project.Domain;

namespace Project.Application.Features.Comments.DTOs
{
    public interface ICommentDto
    {
        public string Content { get; set; } 
        public DateTime Date { get; set; } 
        public int RecipeId { get; set; } 
        public int UserId { get; set; } 

    }
}
