using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain;

namespace Project.Application.Contracts.Persistence
{
    public interface IRecipeRepository : IGenericRepository<Recipe>
    {
    }
}
