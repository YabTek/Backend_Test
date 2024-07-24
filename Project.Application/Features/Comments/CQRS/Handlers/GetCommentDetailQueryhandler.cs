using AutoMapper;
using Project.Application.Contracts.Persistence;
using Project.Application.Features.Comment.CQRS.Queries;
using Project.Application.Features.Comments.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Application.Features.Comment.CQRS.Handlers
{
    public class GetCommentDetailQueryHandler : IRequestHandler<GetCommentDetailQuery, CommentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommentDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CommentDto> Handle(GetCommentDetailQuery request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.CommentRepository.Get(request.Id);
            return _mapper.Map<CommentDto>(comment);
        }
    }
}