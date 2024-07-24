using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRecipeRepository RecipeRepository { get; }
        ICommentRepository CommentRepository { get; }
        Task Save();
    }
}
