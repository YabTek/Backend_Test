using Project.Application.Contracts.Persistence;
using Project.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Persistence.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly ProjectDbContext _dbContext;

        public CommentRepository(ProjectDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
