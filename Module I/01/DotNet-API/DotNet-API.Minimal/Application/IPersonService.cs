using DotNet_API.Minimal.Application.Dto;

namespace DotNet_API.Minimal.Application
{
    public interface IPersonService
    {
        void CreatePeople();
        PersonDto CreatePerson(PersonDto person);
        List<PersonDto> GetPeople();
        PersonDto GetPersonByName(string name);
    }
}