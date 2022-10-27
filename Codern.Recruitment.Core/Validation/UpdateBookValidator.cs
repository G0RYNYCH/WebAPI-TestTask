using Codern.Recruitment.Core.Dtos;
using FluentValidation;

namespace Codern.Recruitment.Core.Validation;
public class UpdateBookValidator : AbstractValidator<UpdateBookDto>
{
    public UpdateBookValidator()
    {
        RuleFor(updateBookDto => updateBookDto.Title)
            .NotEmpty()
            .WithMessage("Title is compalsory to fill")
            .DependentRules(() =>
                {
                    RuleFor(updateBookDto => updateBookDto.Title)
                        .MaximumLength(250)
                        .WithMessage("Use up to 250 symbols");
                });

        RuleFor(updateBookDto => updateBookDto.Title)
            .NotEmpty()
            .MaximumLength(250);


        // check the difference 



        RuleFor(updateBookDto => updateBookDto.Isbn);
            

    }
}
