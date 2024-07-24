// using FluentValidation;
// using Project.Application.Features.Recipes.DTOs;


// namespace Project.Application.Features.Recipes.Validators
// {
//     public class UpdateRecipeDtoValidator : AbstractValidator<UpdateRecipeDto>
//     {
//         public UpdateRecipeDtoValidator()
//         {
//             Include(new IRecipeDtoValidator());

//             RuleFor(recipe => recipe.Id)
//                 .GreaterThan(0).WithMessage("Recipe ID must be a positive number.");
//         }
//     }
// }
