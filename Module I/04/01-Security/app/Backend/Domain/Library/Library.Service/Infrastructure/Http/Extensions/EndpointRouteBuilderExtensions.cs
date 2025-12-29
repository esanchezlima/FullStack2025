using Library.Service.Infrastructure.Http.EndpointHandlers;
using Microsoft.AspNetCore.Authorization;

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
                .WithOpenApi()
                .RequireAuthorization(new AuthorizeAttribute { Roles = "realm-role" });

            authorsEndpoints.MapGet("/{authorId:guid}", AuthorsHandlers.GetAuthorByAuthorIdAsync)
                .WithName("GetAuthor")
                .WithOpenApi()
                .RequireAuthorization(new AuthorizeAttribute { Roles = "client-role" });                

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
        public static void RegisterAuthorsCollectionEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var authorsCollectionEndpoints = endpointRouteBuilder
                .MapGroup("api/authorscollection")
                .WithTags("AuthorsCollection");                

            authorsCollectionEndpoints.MapGet("", AuthorsCollectionHandlers.GetAuthorsCollectionAsync)
                .WithName("GetAuthorsCollection")
                .WithOpenApi();

            authorsCollectionEndpoints.MapPost("", AuthorsCollectionHandlers.CreateAuthorsCollectionAsync)
                .WithName("CreateAuthorsCollection")
                .WithOpenApi();
        }
        public static void RegisterBooksEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var booksEndpoints = endpointRouteBuilder
                .MapGroup("api/authors/{authorId:guid}/books")
                .WithTags("Books");                

            booksEndpoints.MapGet("", BooksHandlers.GetBooksForAuthorAsync)
                .WithName("GetBooksForAuthor")
                .WithOpenApi();

            booksEndpoints.MapGet("/{bookId:guid}", BooksHandlers.GetBookByBookIdForAuthorAsync)
                .WithName("GetBookForAuthor")
                .WithOpenApi();

            booksEndpoints.MapPost("", BooksHandlers.CreateBookForAuthorAsync)
                .ProducesValidationProblem(422)
                .WithName("CreateBookForAuthor")
                .WithOpenApi();

            booksEndpoints.MapDelete("/{bookId:guid}", BooksHandlers.DeleteBookForAuthorAsync)
               .WithName("DeleteBookForAuthor")
               .WithOpenApi();

            booksEndpoints.MapPut("/{bookId:guid}", BooksHandlers.UpdateBookForAuthorAsync)
                .ProducesValidationProblem(422)
                .WithName("UpdateBookForAuthor")
                .WithOpenApi();

            booksEndpoints.MapPatch("/{bookId:guid}", BooksHandlers.PartiallyUpdateBookForAuthorAsync)
                .ProducesValidationProblem(422)
                .WithName("PartiallyUpdateBookForAuthor")
                .WithOpenApi();
        }
        public static void RegisterRootEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var rootEndpoints = endpointRouteBuilder.MapGroup("api").WithTags("Root");

            rootEndpoints.MapGet("", RootHandlers.GetRootAsync)
                .WithName("GetRoot")
                .WithOpenApi();
        }

        public static void RegisterEndpoints(this IEndpointRouteBuilder app)
        {
            app.RegisterRootEndpoints();
            app.RegisterAuthorsEndpoints();
            app.RegisterAuthorsCollectionEndpoints();
            app.RegisterBooksEndpoints();
        }
    }
}
