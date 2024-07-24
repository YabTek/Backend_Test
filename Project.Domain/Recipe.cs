using Project.Domain.Common;
using System;
using System.Collections.Generic;

namespace Project.Domain
{
    public class Recipe : BaseDomainEntity
{
    public string Title { get; set; } 
    public List<Ingredient> Ingredients { get; set; } 
    public string Instructions { get; set; } 
    public int PreparationTime { get; set; } 
    public int UserId { get; set; } 
    public User User { get; set; } 
    public ICollection<Comment> Comments { get; set; } 
}

public class Ingredient : BaseDomainEntity
{
    public string Name { get; set; } 
    public string Quantity { get; set; } 
}
}