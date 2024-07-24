using AutoMapper;
using Project.Application.Responses;
using Project.Application.Contracts.Persistence;
using Project.Application.Exceptions;
using Project.Application.Features.Recipes.CQRS.Commands;
using Project.Application.Features.Recipes.Validators;
using Project.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Application.Features.Recipes.CQRS.Handlers
{
    public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRecipeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
        {
            

            var recipe = await _unitOfWork.RecipeRepository.Get(request.UpdateRecipeDto.Id);

            if (recipe is null)
                throw new NotFoundException(nameof(Recipe), request.UpdateRecipeDto.Id);

            _mapper.Map(request.UpdateRecipeDto, recipe);

            await _unitOfWork.RecipeRepository.Update(recipe);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}