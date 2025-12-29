using Library.Service.Domain.Authors.Entities;

namespace Library.Service.Domain.Authors.Interfaces
{
    public interface IAuthorRepository
    {
        Task AddAuthorAsync(Author author);
        Task<bool> AuthorExists(Guid authorId);
        Task DeleteAuthorAsync(Author author);
        Task<Author> GetAuthorAsync(Guid authorId);
        Task<List<Author>> GetAuthorsAsync();
        Task<IEnumerable<Author>> GetAuthorsAsync(List<Guid> authorIds);
        Task UpdateAuthorAsync(Author author);
    }
}