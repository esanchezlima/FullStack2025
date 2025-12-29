using DotNet_API.Minimal.Application;
using DotNet_API.Minimal.Application.Dto;
using Microsoft.AspNetCore.Http.HttpResults;


namespace DotNet_API.Minimal.Infrastructure.EndpointHandlers
{
    public static class PeopleHandlers
    {
        public static Ok<List<PersonDto>> GetPeople(
            IPersonService personService
        )
        {
            return TypedResults.Ok(personService.GetPeople());
        }
        public static Ok<PersonDto> GetPersonByName(
            IPersonService personService, 
            string name
        )
        {
            return TypedResults.Ok(personService.GetPersonByName(name));
        }
        public static PersonDto CreatePerson(
           IPersonService personService,
           PersonDto person
        )
        {
          return personService.CreatePerson(person);
        }
    }
}
