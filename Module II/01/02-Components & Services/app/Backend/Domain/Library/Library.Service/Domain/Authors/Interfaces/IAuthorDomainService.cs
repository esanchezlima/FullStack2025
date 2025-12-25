using Library.Service.Domain.Authors.Entities;

namespace Library.Service.Domain.Authors.Interfaces
{
    public interface IAuthorDomainService
    {
        Task<Book> TransferBook(Guid sourceAuthorId, Guid targetAuthorId, Guid bookId);
    }
}