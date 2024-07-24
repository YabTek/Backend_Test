using Project.Application.Features.Common;

namespace Project.Application.Features.Comments.DTOs
{
    public class UpdateCommentDto : BaseDto, ICommentDto
    {
        public string Content { get; set; } 
        public DateTime Date { get; set; } 
        public int RecipeId { get; set; } 
        public int UserId { get; set; } 
    }
}
