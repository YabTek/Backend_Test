using Project.Domain.Common;
using System.Collections.Generic;

namespace Project.Domain
{
    public class Comment : BaseDomainEntity
{
    public string Content { get; set; } 
    public DateTime Date { get; set; } 
    public int RecipeId { get; set; } 
    public Recipe Recipe { get; set; } 
    public int UserId { get; set; } 
    public User User { get; set; } 
}

}
