using Library.Service.Application.Dtos;
using Library.Service.Infrastructure.Http.Results.AuthorCollections;
using Library.Service.Infrastructure.Http.Results.Authors;
using Library.Service.Infrastructure.Http.Results.Books;
using Library.Service.Infrastructure.Http.Results.Root;
using Library.Service.Infrastructure.Results.Authors;
using Microsoft.AspNetCore.JsonPatch;

namespace Library.Service.Application.Interfaces
{
    public interface ILibraryApplicationService
    {
        Task<GetAuthorsResult> GetAuthorsAsync(AuthorsResourceParameters authorsResourceParameters);
        Task<bool> AuthorExistsAsync(Guid authorId);
        Task<CreateAuthorResult> CreateAuthorAsync(AuthorForCreationDto author);
        Task<CreateAuthorWithDateOfDeathResult> CreateAuthorWithDateOfDeathAsync(AuthorForCreationWithDateOfDeathDto author);
        Task<bool?> DeleteAuthorAsync(Guid authorId);
        Task<GetAuthorByAuthorIdResult> GetAuthorByAuthorIdAsync(Guid authorId, string fields);
        Task<UpdateAuthorResult> UpdateAuthorAsync(Guid authorId, AuthorForUpdateDto author);

        Task<CreateBookForAuthorResult> CreateBookForAuthorAsync(Guid authorId, BookForCreationDto book);
        Task<DeleteBookForAuthorResult> DeleteBookForAuthorAsync(Guid authorId, Guid bookId);
        Task<GetAuthorCollectionResult> GetAuthorsCollectionAsync(List<Guid> authorsIds);
        Task<GetBookForAuthorResult> GetBookByBookIdForAuthorAsync(Guid authorId, Guid bookId);
        Task<GetBooksForAuthorResult> GetBooksForAuthorAsync(Guid authorId);
        Task<PartiallyUpdateBookForAuthorResult> PartiallyUpdateBookForAuthor(Guid authorId, Guid bookId, JsonPatchDocument<BookForUpdateDto> patchDoc);
        Task<UpdateBookForAuthorResult> UpdateBookForAuthorAsync(Guid authorId, Guid bookId, BookForUpdateDto bookDto);

        Task<CreateAuthorCollectionResult> CreateAuthorCollectionAsync(IEnumerable<AuthorForCreationDto> authorCollection);

        Task<GetRootResult> GetRootAsync();

    }
}