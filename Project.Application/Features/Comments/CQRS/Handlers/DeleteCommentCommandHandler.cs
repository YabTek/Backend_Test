using AutoMapper;
using Project.Application.Contracts.Persistence;
using Project.Application.Exceptions;
using Project.Application.Features.Comment.CQRS.Commands;
using Project.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Application.Features.Comment.CQRS.Handlers
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _unitOfWork.CommentRepository.Get(request.Id);

            if (comment == null)
                throw new NotFoundException(nameof(Comment), request.Id);

            await _unitOfWork.CommentRepository.Delete(comment);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}