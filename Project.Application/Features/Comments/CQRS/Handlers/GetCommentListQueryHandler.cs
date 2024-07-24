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
    public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery, List<CommentDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommentListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {
            var comments = await _unitOfWork.CommentRepository.GetAll();
            return _mapper.Map<List<CommentDto>>(comments);
        }
    }
}