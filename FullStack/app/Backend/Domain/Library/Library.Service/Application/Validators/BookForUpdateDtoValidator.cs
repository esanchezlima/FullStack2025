using FluentValidation;
using Library.Service.Application.Dtos;

namespace Library.Service.Application.Validators
{
    public class BookForUpdateDtoValidator : BookForManipulationDtoValidator<BookForUpdateDto>
    {
        public BookForUpdateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty().NotEqual(x => x.Title)
                .WithMessage("The provided description should be different from the title.");            
        }
    }

}
