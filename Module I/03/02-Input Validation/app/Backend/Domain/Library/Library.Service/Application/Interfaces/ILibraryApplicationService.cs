using Library.Service.Application.Dtos;
using Library.Service.Infrastructure.Http.Results.Authors;
using Library.Service.Infrastructure.Results.Authors;

namespace Library.Service.Application.Interfaces
{
    public interface ILibraryApplicationService
    {       
        Task<GetAuthorsResult> GetAuthorsAsync();
        Task<bool> AuthorExistsAsync(Guid authorId);
        Task<CreateAuthorResult> CreateAuthorAsync(AuthorForCreationDto author);
        Task<CreateAuthorWithDateOfDeathResult> CreateAuthorWithDateOfDeathAsync(AuthorForCreationWithDateOfDeathDto author);        
        Task<bool?> DeleteAuthorAsync(Guid authorId);
        Task<GetAuthorByAuthorIdResult> GetAuthorByAuthorIdAsync(Guid authorId);        
        Task<UpdateAuthorResult> UpdateAuthorAsync(Guid authorId, AuthorForUpdateDto author);        
    }
}