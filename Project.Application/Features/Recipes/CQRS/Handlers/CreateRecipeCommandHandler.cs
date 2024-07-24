using AutoMapper;
using Project.Application.Contracts.Persistence;
using Project.Application.Features.Recipes.CQRS.Commands;
using Project.Application.Responses;
using MediatR;
using Project.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project.Application.Features.Recipes.CQRS.Handlers
{
    public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRecipeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            // Direct validation logic
            if (string.IsNullOrEmpty(request.CreateRecipeDto.Title) || request.CreateRecipeDto.Title.Length > 200)
            {
                response.Success = false;
                response.Message = "Title is required and cannot exceed 200 characters.";
                return response;
            }

            if (string.IsNullOrEmpty(request.CreateRecipeDto.Instructions))
            {
                response.Success = false;
                response.Message = "Instructions are required.";
                return response;
            }

            if (request.CreateRecipeDto.PreparationTime < 0)
            {
                response.Success = false;
                response.Message = "Preparation time must be a positive integer.";
                return response;
            }

            try
            {
                // Map DTO to Domain Entity
                var recipe = _mapper.Map<Project.Domain.Recipe>(request.CreateRecipeDto);

                // Add the Recipe to the repository
                recipe = await _unitOfWork.RecipeRepository.Add(recipe);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Recipe created successfully";
                response.Id = recipe.Id; // Assuming Id is a property of BaseCommandResponse
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred: {ex.Message}";
            }

            return response;
        }
    }
}
