using Library.Service.Application.Dtos;
using Library.Service.Application.Interfaces;
using Library.Service.Infrastructure.Http.Helpers.QueryParametersTypes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Library.Service.Infrastructure.Http.EndpointHandlers
{
    public static class AuthorsCollectionHandlers
    {
        public static async Task<Results<BadRequest, NotFound, Ok<IEnumerable<AuthorDto>>>> GetAuthorsCollectionAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            [FromQuery] QueryParameterListGuidsType authorsIds
        )
        {            
            if (authorsIds == null || !authorsIds.Items.Any())
            {
                return TypedResults.BadRequest();
            }

            var result = await _libraryApplicationService.GetAuthorsCollectionAsync(authorsIds.Items);
            //var result = new GetAuthorCollectionResult();

            if (!result.AuthorsFound)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(result.AuthorCollection);

        }
        public static async Task<Results<BadRequest, CreatedAtRoute<IEnumerable<AuthorDto>>>> CreateAuthorsCollectionAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            [FromBody] IEnumerable<AuthorForCreationDto> authorCollection
        )
        {
            if (authorCollection == null)
            {
                return TypedResults.BadRequest();
            }

            var result = await _libraryApplicationService.CreateAuthorCollectionAsync(authorCollection);            

            return TypedResults.CreatedAtRoute(result.AuthorsCollection, $"GetAuthorsCollection", new { authorsIds = result.AuhtorsIdsAsString });
        }
    }
}
