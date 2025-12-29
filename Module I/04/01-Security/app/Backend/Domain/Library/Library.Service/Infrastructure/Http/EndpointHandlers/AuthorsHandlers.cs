using Library.Service.Application.Dtos;
using Library.Service.Application.Interfaces;
using Library.Service.Domain.Authors.Entities;
using Library.Service.Infrastructure.Http.Extensions;
using Library.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Library.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping;
using Library.Service.Infrastructure.Persistence.Helpers.DataMapping.TypeHelper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Text.Json;

namespace Library.Service.Infrastructure.Http.EndpointHandlers
{
    public static class AuthorsHandlers
    {
        public static async Task<Results<BadRequest, Ok<IEnumerable<ExpandoObject>>, Ok<LinkedCollectionResource>, Ok<List<AuthorDto>>>> GetAuthorsAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            [FromServices] IAuthorPropertyMappingService _authorPropertyMappingService,
            [FromServices] ITypeHelperService _typeHelperService,
            [FromServices] IHttpContextAccessor _httpContextAccessor,
            [FromHeader(Name = "Accept")] string? mediaType,
            [AsParameters] AuthorsResourceParameters authorsResourceParameters
        )
        {
            if (!_authorPropertyMappingService.ValidMappingExistsFor(authorsResourceParameters.OrderBy) || !_typeHelperService.TypeHasProperties<AuthorDto>(authorsResourceParameters.Fields))
            {
                return TypedResults.BadRequest();
            }

            var result = await _libraryApplicationService.GetAuthorsAsync(authorsResourceParameters);            
            _httpContextAccessor.HttpContext.Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.PaginationMetadata, new JsonSerializerOptions { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping }));

            switch (mediaType)
            {
                case "application/vnd.erick.hateoas+json":
                    return TypedResults.Ok(result.LinkedCollectionResource);
                default:
                    return TypedResults.Ok(result.ShapedAuthors);
            }
        }
        public static async Task<Results<BadRequest, NotFound, Ok<ExpandoObject>, Ok<IDictionary<string, object>>, Ok<AuthorDto>>> GetAuthorByAuthorIdAsync(
           [FromServices] ILibraryApplicationService _libraryApplicationService,
           [FromServices] ITypeHelperService _typeHelperService,
           [FromHeader(Name = "Accept")] string? mediaType,
           [FromQuery] string? fields,
           Guid authorId
        )
        {
            if (!_typeHelperService.TypeHasProperties<AuthorDto>(fields))
            {
                return TypedResults.BadRequest();
            }

            var result = await _libraryApplicationService.GetAuthorByAuthorIdAsync(authorId, fields);
            if (result == null)
            {
                return TypedResults.NotFound();
            }

            switch (mediaType)
            {
                case "application/vnd.erick.hateoas+json":
                    return TypedResults.Ok(result.LinkedResource);
                default:
                    return TypedResults.Ok(result.ShapedAuthor);
            }
        }
        public static async Task<Results<BadRequest, UnprocessableEntity<List<ValidationResult>>, CreatedAtRoute<ExpandoObject>, CreatedAtRoute<AuthorDto>, Ok<AuthorDto>>> CreateAuthorAsync(
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

            Guid authorId = (Guid)(result.ShapedAuthor as IDictionary<string, object>)["AuthorId"];

            return TypedResults.CreatedAtRoute(result.ShapedAuthor, $"GetAuthor", new { authorId });
        }
        public static async Task<Results<BadRequest, UnprocessableEntity<List<ValidationResult>>, CreatedAtRoute<ExpandoObject>, CreatedAtRoute<AuthorDto>, Ok<AuthorDto>>> CreateAuthorWithDateOfDeathAsync(
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

            Guid authorId = (Guid)(result.ShapedAuthor as IDictionary<string, object>)["AuthorId"];

            return TypedResults.CreatedAtRoute(result.ShapedAuthor, $"GetAuthor", new { authorId });
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
