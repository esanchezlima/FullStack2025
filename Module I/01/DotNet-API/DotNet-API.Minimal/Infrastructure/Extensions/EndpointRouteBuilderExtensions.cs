using DotNet_API.Minimal.Infrastructure.EndpointHandlers;

namespace DotNet_API.Minimal.Infrastructure.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterPeopleEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var peopleEndpoints = endpointRouteBuilder.MapGroup("/people");
            peopleEndpoints.MapGet("", PeopleHandlers.GetPeople);
            peopleEndpoints.MapGet("/{name}", PeopleHandlers.GetPersonByName);
            peopleEndpoints.MapPost("", PeopleHandlers.CreatePerson);
        }
    }
}
