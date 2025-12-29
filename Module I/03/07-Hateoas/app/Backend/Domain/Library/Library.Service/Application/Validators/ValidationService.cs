using FluentValidation;
using FluentValidation.Results;
using Library.Service.Application.Dtos;
using Library.Service.Application.Interfaces;

namespace Library.Service.Application.Validators
{
    public class ValidationService : IValidationService
    {
        private readonly IValidator<AuthorForCreationDto> _authorCreationValidator;
        private readonly IValidator<AuthorForCreationWithDateOfDeathDto> _authorCreationWithDateOfDeathValidator;
        private readonly IValidator<AuthorForUpdateDto> _authorUpdateValidator;
        private readonly IValidator<AuthorsResourceParameters> _authorsResourceParametersValidator;

        public ValidationService(
            IValidator<AuthorForCreationDto> authorCreationValidator,
            IValidator<AuthorForUpdateDto> authorUpdateValidator,
            IValidator<AuthorForCreationWithDateOfDeathDto> authorCreationWithDateOfDeathValidator,
            IValidator<AuthorsResourceParameters> authorsResourceParametersValidator
        )
        {
            _authorCreationValidator = authorCreationValidator;
            _authorUpdateValidator = authorUpdateValidator;
            _authorCreationWithDateOfDeathValidator = authorCreationWithDateOfDeathValidator;
            _authorsResourceParametersValidator = authorsResourceParametersValidator;
        }
        public ValidationResult ValidateAuthorCreation(AuthorForCreationDto dto)
        {
            return _authorCreationValidator.Validate(dto);
        }
        public ValidationResult ValidateAuthorCreationWithDateOfDeath(AuthorForCreationWithDateOfDeathDto dto)
        {
            return _authorCreationWithDateOfDeathValidator.Validate(dto);
        }
        public ValidationResult ValidateAuthorUpdate(AuthorForUpdateDto dto)
        {
            return _authorUpdateValidator.Validate(dto);
        }
        public ValidationResult ValidateAuthorsResourceParameters(AuthorsResourceParameters resource)
        {
            return _authorsResourceParametersValidator.Validate(resource);
        }
    }
}
