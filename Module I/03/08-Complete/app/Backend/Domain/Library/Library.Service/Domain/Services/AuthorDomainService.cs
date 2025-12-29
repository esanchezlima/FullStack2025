using Library.Service.Domain.Authors.Interfaces;
using Library.Service.Domain.Authors.Entities;

namespace Library.Service.Domain.Authors.Services
{
    public class AuthorDomainService : IAuthorDomainService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public AuthorDomainService(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public async Task<Book> TransferBook(Guid sourceAuthorId, Guid targetAuthorId, Guid bookId)
        {
            var sourceAuthor = await _authorRepository.GetAuthorAsync(sourceAuthorId);
            var targetAuthor = await _authorRepository.GetAuthorAsync(targetAuthorId);
            var book = await _bookRepository.GetBookForAuthorAsync(sourceAuthorId, bookId);

            if (sourceAuthor == null || targetAuthor == null || book == null)
            {
                throw new Exception("Invalid operation");
            }

            book.AuthorId = targetAuthorId;

            return await _bookRepository.UpdateBookAsync(book);
        }
    }
}
