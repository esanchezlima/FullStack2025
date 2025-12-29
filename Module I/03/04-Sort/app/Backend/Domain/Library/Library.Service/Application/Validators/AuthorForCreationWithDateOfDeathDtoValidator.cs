using FluentValidation;
using Library.Service.Application.Dtos;

namespace Library.Service.Application.Validators
{
    public class AuthorForCreationWithDateOfDeathDtoValidator : AbstractValidator<AuthorForCreationWithDateOfDeathDto>
    { 
        public AuthorForCreationWithDateOfDeathDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();            
        }
    }

}
