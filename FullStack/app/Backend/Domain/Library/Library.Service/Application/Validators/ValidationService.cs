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

        private readonly IValidator<BookForCreationDto> _bookCreationValidator;
        private readonly IValidator<BookForUpdateDto> _bookUpdateValidator;
        public ValidationService(
            IValidator<AuthorForCreationDto> authorCreationValidator,
            IValidator<AuthorForUpdateDto> authorUpdateValidator,
            IValidator<AuthorForCreationWithDateOfDeathDto> authorCreationWithDateOfDeathValidator,
            IValidator<AuthorsResourceParameters> authorsResourceParametersValidator,
            IValidator<BookForCreationDto> bookCreationValidator,
            IValidator<BookForUpdateDto> bookUpdateValidator
        )
        {
            _authorCreationValidator = authorCreationValidator;
            _authorUpdateValidator = authorUpdateValidator;
            _authorCreationWithDateOfDeathValidator = authorCreationWithDateOfDeathValidator;
            _authorsResourceParametersValidator = authorsResourceParametersValidator;
            _bookCreationValidator = bookCreationValidator;
            _bookUpdateValidator = bookUpdateValidator;
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

        public ValidationResult ValidateBookCreation(BookForCreationDto dto)
        {
            return _bookCreationValidator.Validate(dto);
        }

        public ValidationResult ValidateBookUpdate(BookForUpdateDto dto)
        {
            return _bookUpdateValidator.Validate(dto);
        }
    }
}
