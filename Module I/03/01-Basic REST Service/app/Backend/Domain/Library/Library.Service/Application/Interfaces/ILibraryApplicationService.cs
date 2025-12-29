using Library.Service.Application.Dtos;
using Library.Service.Infrastructure.Http.Results.Authors;

namespace Library.Service.Application.Interfaces
{
    public interface ILibraryApplicationService
    {       
        Task<List<AuthorDto>> GetAuthorsAsync();
        Task<bool> AuthorExistsAsync(Guid authorId);
        Task<AuthorDto> CreateAuthorAsync(AuthorForCreationDto author);
        Task<AuthorDto> CreateAuthorWithDateOfDeathAsync(AuthorForCreationWithDateOfDeathDto author);        
        Task<bool?> DeleteAuthorAsync(Guid authorId);
        Task<AuthorDto> GetAuthorByAuthorIdAsync(Guid authorId);        
        Task<UpdateAuthorResult> UpdateAuthorAsync(Guid authorId, AuthorForUpdateDto author);        
    }
}