using AutoMapper;
using Project.Application.Responses;
using Project.Application.Contracts.Persistence;
using Project.Application.Exceptions;
using Project.Application.Features.Comment.CQRS.Commands;
using Project.Application.Features.Comments.Validators;
using Project.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Application.Features.Comments.CQRS.Handlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCommentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateCommentDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var comment = await _unitOfWork.CommentRepository.Get(request.UpdateCommentDto.Id);

            if (comment is null)
                throw new NotFoundException(nameof(Comment), request.UpdateCommentDto.Id);

            _mapper.Map(request.UpdateCommentDto, comment);

            await _unitOfWork.CommentRepository.Update(comment);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}