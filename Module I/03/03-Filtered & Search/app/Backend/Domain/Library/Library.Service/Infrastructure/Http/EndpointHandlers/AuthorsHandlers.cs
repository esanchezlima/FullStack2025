using Library.Service.Application.Dtos;
using Library.Service.Application.Interfaces;
using Library.Service.Domain.Authors.Entities;
using Library.Service.Infrastructure.Http.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace Library.Service.Infrastructure.Http.EndpointHandlers
{
    public static class AuthorsHandlers
    {
        public static async Task<Results<BadRequest, Ok<List<AuthorDto>>>> GetAuthorsAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            [AsParameters] AuthorsResourceParameters authorsResourceParameters
        )
        {
            var result = await _libraryApplicationService.GetAuthorsAsync(authorsResourceParameters);
            return TypedResults.Ok(result.Authors);
        }
        public static async Task<Results<BadRequest, NotFound, Ok<AuthorDto>>> GetAuthorByAuthorIdAsync(
           [FromServices] ILibraryApplicationService _libraryApplicationService,
           Guid authorId
        )
        {
            var result = await _libraryApplicationService.GetAuthorByAuthorIdAsync(authorId);
            if (result == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(result.Author);
        }
        public static async Task<Results<BadRequest, UnprocessableEntity<List<ValidationResult>>, CreatedAtRoute<AuthorDto>, Ok<AuthorDto>>> CreateAuthorAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            [FromBody] AuthorForCreationDto author
        )
        {
            if (author == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _libraryApplicationService.CreateAuthorAsync(author);
            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }

            return TypedResults.CreatedAtRoute(result.Author, $"GetAuthor", new { result.Author.AuthorId });
        }
        public static async Task<Results<BadRequest, UnprocessableEntity<List<ValidationResult>>, CreatedAtRoute<AuthorDto>, Ok<AuthorDto>>> CreateAuthorWithDateOfDeathAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            [FromBody] AuthorForCreationWithDateOfDeathDto author
        )
        {
            if (author == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _libraryApplicationService.CreateAuthorWithDateOfDeathAsync(author);
            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }

            Guid authorId = result.Author.AuthorId;
            return TypedResults.CreatedAtRoute(result.Author, $"GetAuthor", new { authorId });
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
        public static async Task<Results<BadRequest, NotFound, NoContent, CreatedAtRoute<AuthorDto>, UnprocessableEntity<List<ValidationResult>>, Ok<AuthorDto>>> UpdateAuthorAsync(
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
            if (!result.Success)
            {
                return TypedResults.UnprocessableEntity(result.ValidationErrors);
            }

            if (result.Success && result.AuthorUpserted != null)
            {
                return TypedResults.CreatedAtRoute(result.AuthorUpserted, $"GetAuthor", new { authorId = result.AuthorUpserted.AuthorId });
            }

            return TypedResults.NoContent();
        }
    }
}
