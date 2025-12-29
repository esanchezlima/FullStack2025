using Library.Service.Application.Dtos;
using Library.Service.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Library.Service.Infrastructure.Http.EndpointHandlers
{
    public static class AuthorsHandlers
    {
        public static async Task<Results<BadRequest, Ok<List<AuthorDto>>>> GetAuthorsAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService
        )
        {
            var authors = await _libraryApplicationService.GetAuthorsAsync();
            return TypedResults.Ok(authors);            
        }
        public static async Task<Results<BadRequest, Ok<AuthorDto>>> GetAuthorByAuthorIdAsync(
           [FromServices] ILibraryApplicationService _libraryApplicationService,
           Guid authorId
        )
        {
            var result = await _libraryApplicationService.GetAuthorByAuthorIdAsync(authorId);
            return TypedResults.Ok(result);
        }
        public static async Task<Results<BadRequest, Ok<AuthorDto>>> CreateAuthorAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            [FromBody] AuthorForCreationDto author
        )
        {
            if (author == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _libraryApplicationService.CreateAuthorAsync(author);
            return TypedResults.Ok(result);
        }
        public static async Task<Results<BadRequest, Ok<AuthorDto>>> CreateAuthorWithDateOfDeathAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            [FromBody] AuthorForCreationWithDateOfDeathDto author
        )
        {
            if (author == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _libraryApplicationService.CreateAuthorWithDateOfDeathAsync(author);
            return TypedResults.Ok(result);
        }
        public static async Task<Results<NotFound, NoContent>> DeleteAuthorAsync(
          [FromServices] ILibraryApplicationService _libraryApplicationService,
          Guid authorId
       )
        {
            var result = await _libraryApplicationService.DeleteAuthorAsync(authorId);

            if (result == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.NoContent();
        }
        public static async Task<Results<BadRequest, NotFound, NoContent, Ok<AuthorDto>>> UpdateAuthorAsync(
           [FromServices] ILibraryApplicationService _libraryApplicationService,
           [FromBody] AuthorForUpdateDto author,
           Guid authorId
        )
        {
            if (author == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _libraryApplicationService.UpdateAuthorAsync(authorId, author);

            if (result.Success && result.AuthorUpserted != null)
            {
                return TypedResults.Ok(result.AuthorUpserted);
            }

            return TypedResults.NoContent();
        }
    }
}
