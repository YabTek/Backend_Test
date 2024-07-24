using System.Collections.Generic;
using Project.Domain;
using Project.Application.Features.Common;


namespace Project.Application.Features.Comments.DTOs
{
    public class CommentDto : BaseDto, ICommentDto 
    {
        public string Content { get; set; } 
        public DateTime Date { get; set; } 
        public int RecipeId { get; set; } 
        public Recipe Recipe { get; set; } 
        public int UserId { get; set; } 
        public User User { get; set; }
    }
}
