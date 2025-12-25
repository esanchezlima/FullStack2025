using Library.Service.Application.Interfaces;
using Library.Service.Infrastructure.Http.Results.Root;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Library.Service.Infrastructure.Http.EndpointHandlers
{
    public static class RootHandlers
    {
        public static async Task<Results<NoContent, Ok<GetRootResult>>> GetRootAsync(
            [FromServices] ILibraryApplicationService _libraryApplicationService,
            [FromServices] IHttpContextAccessor _httpContextAccessor            
        )
        {
            var result = await _libraryApplicationService.GetRootAsync();
                        
            return TypedResults.Ok(result);            
        }
    }
}
