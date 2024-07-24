using Project.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain

{
    public class User : BaseDomainEntity
    {
        public string UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

        public ICollection<Recipe> Recipes { get; set; } 
        public ICollection<Comment> Comments { get; set; } 

    }
}