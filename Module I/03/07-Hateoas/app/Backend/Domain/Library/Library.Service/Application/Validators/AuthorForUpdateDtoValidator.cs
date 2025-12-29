using FluentValidation;
using Library.Service.Application.Dtos;

namespace Library.Service.Application.Validators
{
    public class AuthorForUpdateDtoValidator : AbstractValidator<AuthorForUpdateDto>
    { 
        public AuthorForUpdateDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();            
        }
    }

}
