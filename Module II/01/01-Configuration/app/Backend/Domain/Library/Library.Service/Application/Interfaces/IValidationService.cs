using FluentValidation.Results;
using Library.Service.Application.Dtos;

namespace Library.Service.Application.Interfaces
{
    public interface IValidationService
    {
        ValidationResult ValidateAuthorCreation(AuthorForCreationDto dto);
        ValidationResult ValidateAuthorCreationWithDateOfDeath(AuthorForCreationWithDateOfDeathDto dto);
        ValidationResult ValidateAuthorUpdate(AuthorForUpdateDto dto);
        ValidationResult ValidateAuthorsResourceParameters(AuthorsResourceParameters resource);
        ValidationResult ValidateBookCreation(BookForCreationDto dto);
        ValidationResult ValidateBookUpdate(BookForUpdateDto dto);
    }
}