using AspNetCore.JsonPatch;
using Library.Service.Application.Dtos;
using Library.Service.Application.Interfaces;
using Library.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.Service.Infrastructure.Http.EndpointHandlers
{
    public static class BooksHandlers
    {
        public static async Task<Results<NotFound,Ok<LinkedCollectionResourceWrapperDto<BookDto>>>> GetBooksForAuthorAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            Guid authorId
        )
        {
            if (!await _libraryApplicationService.AuthorExistsAsync(authorId))
            {
                return TypedResults.NotFound();
            }

            var result = await _libraryApplicationService.GetBooksForAuthorAsync(authorId);

            return TypedResults.Ok(result.LinkedCollectionResource);
        }
        public static async Task<Results<NotFound,Ok<BookDto>>> GetBookByBookIdForAuthorAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            Guid authorId,
            Guid bookId
        )
        {
            if (!await _libraryApplicationService.AuthorExistsAsync(authorId))
            {
                return TypedResults.NotFound();
            }

            var result = await _libraryApplicationService.GetBookByBookIdForAuthorAsync(authorId, bookId);
            if (result == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(result.LinkedResource);
        }
        public static async Task<Results<BadRequest, NotFound, UnprocessableEntity<List<ValidationResult>>, CreatedAtRoute<BookDto>>> CreateBookForAuthorAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            Guid authorId,
            [FromBody] BookForCreationDto book
        )
        {
            if (book == null)
            {
                return TypedResults.BadRequest();
            }

            if (! await _libraryApplicationService.AuthorExistsAsync(authorId))
            {
                return TypedResults.NotFound();
            }

            var result = await _libraryApplicationService.CreateBookForAuthorAsync(authorId, book);

            if (!result.Success)
            {                
                return TypedResults.UnprocessableEntity(result.ValidationErrors);  
            }

            return TypedResults.CreatedAtRoute(result.LinkedResource, $"GetBookForAuthor", new { authorId , bookId = result.LinkedResource.BookId });            
        }
        public static async Task<Results<NotFound, NoContent>> DeleteBookForAuthorAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            Guid authorId,
            Guid bookId
        )
        {
            var result = await _libraryApplicationService.DeleteBookForAuthorAsync(authorId, bookId);

            if (result == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.NoContent();
        }
        public static async Task<Results<BadRequest, NotFound, NoContent, CreatedAtRoute<BookDto>, UnprocessableEntity<List<ValidationResult>>>> UpdateBookForAuthorAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            [FromBody] BookForUpdateDto book,
            Guid authorId,
            Guid bookId
        )
        {
            if (book == null)
            {
                return TypedResults.BadRequest();
            }

            if (!await _libraryApplicationService.AuthorExistsAsync(authorId))
            {
                return TypedResults.NotFound();
            }

            var result = await _libraryApplicationService.UpdateBookForAuthorAsync(authorId, bookId, book);

            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }
            else
            {
                if (result.Success && result.BookUpserted != null)
                {
                    return TypedResults.CreatedAtRoute(result.BookUpserted, "UpdateBookForAuthor", new { authorId, bookId = result.BookUpserted.BookId });
                }
            }

            return TypedResults.NoContent();
        }

        public static async Task<Results<BadRequest, NotFound, NoContent, CreatedAtRoute<BookDto>, UnprocessableEntity<List<ValidationResult>>>> PartiallyUpdateBookForAuthorAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            [FromBody] JsonPatchDocument<BookForUpdateDto> patchDoc,
            Guid authorId,
            Guid bookId
        )
        {
            if (patchDoc == null)
            {
                return TypedResults.BadRequest();
            }

            if (!await _libraryApplicationService.AuthorExistsAsync(authorId))
            {
                return TypedResults.NotFound();
            }

            var result = await _libraryApplicationService.PartiallyUpdateBookForAuthor(authorId, bookId, patchDoc);

            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }
            else
            {
                if (result.BookUpserted != null)
                {
                    return TypedResults.CreatedAtRoute(result.BookUpserted, "GetBookForAuthor", new { authorId, bookId = result.BookUpserted.BookId });
                }
            }

            return TypedResults.NoContent();
        }
    }
}
