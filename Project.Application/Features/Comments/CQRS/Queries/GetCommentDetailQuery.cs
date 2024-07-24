using Project.Application.Features.Comments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Application.Features.Comment.CQRS.Queries
{
    public class GetCommentDetailQuery : IRequest<CommentDto>
    {
        public int Id { get; set; }
    }
}