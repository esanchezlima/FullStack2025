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

            authorsEndpoints.MapGet("/{authorId:guid}", AuthorsHandlers.GetAuthorByAuthorIdAsync)
                .WithName("GetAuthor")
                .WithOpenApi();

            authorsEndpoints.MapPost("", AuthorsHandlers.CreateAuthorAsync)
               .ProducesValidationProblem(422)
               .WithName("CreateAuthor")
               .WithOpenApi();

            authorsEndpoints.MapPost("/WithDateOfDeath", AuthorsHandlers.CreateAuthorWithDateOfDeathAsync)
                .ProducesValidationProblem(422)
                .WithName("CreateAuthorWithDateOfDeath")
                .WithOpenApi();

            authorsEndpoints.MapDelete("/{authorId:guid}", AuthorsHandlers.DeleteAuthorAsync)
                .WithName("DeleteAuthor")
                .WithOpenApi();

            authorsEndpoints.MapPut("/{authorId:guid}", AuthorsHandlers.UpdateAuthorAsync)
                .ProducesValidationProblem(422)
                .WithName("UpdateAuthor")
                .WithOpenApi();
        }
        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.RegisterAuthorsEndpoints();
        }
    }
}
