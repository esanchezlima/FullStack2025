using DotNet_API.Classic.Application.Dto;

namespace DotNet_API.Classic.Application
{
    public interface IPersonService
    {
        void CreatePeople();
        List<PersonDto> GetPeople();
        PersonDto GetPersonByName(string name);
    }
}