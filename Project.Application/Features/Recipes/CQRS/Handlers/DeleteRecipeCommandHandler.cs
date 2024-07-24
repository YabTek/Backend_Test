using AutoMapper;
using Project.Application.Contracts.Persistence;
using Project.Application.Exceptions;
using Project.Application.Features.Recipes.CQRS.Commands;
using Project.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Application.Features.Recipes.CQRS.Handlers
{
    public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRecipeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
        {
            var recipe = await _unitOfWork.RecipeRepository.Get(request.Id);

            if (recipe == null)
                throw new NotFoundException(nameof(Recipe), request.Id);

            await _unitOfWork.RecipeRepository.Delete(recipe);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}