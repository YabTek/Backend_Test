namespace Project.Application.Features.Comments.DTOs
{
    public class CreateCommentDto : ICommentDto
    {
       public string Content { get; set; } 
        public DateTime Date { get; set; } 
        public int UserId { get; set; }
        public int RecipeId { get; set; } 
 
    }
}
