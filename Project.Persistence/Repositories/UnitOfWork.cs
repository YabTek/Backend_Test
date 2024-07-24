using Project.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ProjectDbContext _context;

        private IUserRepository _userRepository;
        private ICommentRepository _commentRepository;
        private IRecipeRepository _recipeRepository;

        public UnitOfWork(ProjectDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository { 
            get 
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository; 
            } 
         }
        public ICommentRepository CommentRepository { 
            get 
            {
                if (_commentRepository == null)
                    _commentRepository = new CommentRepository(_context);
                return _commentRepository; 
            } 
         }
        public IRecipeRepository RecipeRepository { 
            get 
            {
                if (_recipeRepository == null)
                    _recipeRepository = new RecipeRepository(_context);
                return _recipeRepository; 
            } 
         }
        

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
