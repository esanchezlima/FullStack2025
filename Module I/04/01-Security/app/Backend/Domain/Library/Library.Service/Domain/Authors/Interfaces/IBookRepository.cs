using Library.Service.Domain.Authors.Entities;

namespace Library.Service.Domain.Authors.Interfaces
{
    public interface IBookRepository
    {
        Task AddBookForAuthorAsync(Guid authorId, Book book);
        Task DeleteBookAsync(Book book);
        Task<Book> GetBookForAuthorAsync(Guid authorId, Guid bookId);
        Task<IEnumerable<Book>> GetBooksForAuthorAsync(Guid authorId);
        Task<Book> UpdateBookAsync(Book book);
        Task UpdateBookForAuthorAsync(Book book);
    }
}