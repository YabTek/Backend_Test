using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project.Domain;

namespace Project.Application.Contracts.Persistence
{
    public interface ICommentRepository : IGenericRepository<Project.Domain.Comment>
    {
    }
}
