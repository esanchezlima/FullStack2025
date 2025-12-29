using Library.Service.Application.Dtos;
namespace Library.Service.Application.Interfaces
{
    public interface ILibraryApplicationService
    {       
        Task<List<AuthorDto>> GetAuthorsAsync();
    }
}