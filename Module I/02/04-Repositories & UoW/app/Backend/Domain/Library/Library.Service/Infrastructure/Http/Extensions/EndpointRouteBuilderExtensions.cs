using Library.Service.Infrastructure.Http.EndpointHandlers;

namespace Library.Service.Infrastructure.Http.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterAuthorsEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var authorsEndpoints = endpointRouteBuilder
                .MapGroup("api/authors")
                .WithTags("Authors");                

            authorsEndpoints.MapGet("", AuthorsHandlers.GetAuthorsAsync)
                .WithName("GetAuthors")                
                .WithOpenApi();
        }
        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.RegisterAuthorsEndpoints();
        }
    }
}
