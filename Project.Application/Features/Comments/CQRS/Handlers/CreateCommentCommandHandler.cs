using AutoMapper;
using Project.Application.Contracts.Persistence;
using Project.Application.Features.Comment.CQRS.Commands;
using Project.Application.Features.Comments.Validators;
using Project.Application.Responses;
using MediatR;
using Project.Domain;
using System;
using System.Threading.Tasks; // For async/await functionality
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Application.Features.Comments_.CQRS.Handlers
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCommentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateCommentDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var comment = _mapper.Map<Project.Domain.Comment>(request.CreateCommentDto);

                comment = await _unitOfWork.CommentRepository.Add(comment);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = comment.Id;
            }

            return response;
        }
    }
}
