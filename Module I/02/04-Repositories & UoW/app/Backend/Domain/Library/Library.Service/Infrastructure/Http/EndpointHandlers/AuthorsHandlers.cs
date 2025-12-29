using Library.Service.Application.Dtos;
using Library.Service.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Library.Service.Infrastructure.Http.EndpointHandlers
{
    public static class AuthorsHandlers
    {
        public static async Task<IResult> GetAuthorsAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService
        )
        {
            var authors = await _libraryApplicationService.GetAuthorsAsync();
            return TypedResults.Ok(authors);            
        }
    }
}
