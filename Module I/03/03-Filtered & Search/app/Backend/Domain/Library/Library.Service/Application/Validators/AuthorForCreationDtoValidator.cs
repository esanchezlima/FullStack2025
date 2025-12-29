using FluentValidation;
using Library.Service.Application.Dtos;

namespace Library.Service.Application.Validators
{
    public class AuthorForCreationDtoValidator : AbstractValidator<AuthorForCreationDto>
    { 
        public AuthorForCreationDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();            
        }
    }

}
