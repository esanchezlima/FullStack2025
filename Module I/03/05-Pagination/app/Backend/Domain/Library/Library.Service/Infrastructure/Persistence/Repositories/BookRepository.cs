using Library.Service.Infrastructure.Persistence.Contexts;
using Library.Service.Domain.Authors.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Service.Domain.Authors.Interfaces;
using Library.Service.Infrastructure.Persistence.Contexts;

namespace Library.Service.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(
            LibraryContext context
        )
        {
            _context = context;
        }
        public async Task AddBookForAuthorAsync(Guid authorId, Book book)
        {
            book.AuthorId = authorId;
            await _context.Books.AddAsync(book);
        }
        public async Task DeleteBookAsync(Book book)
        {
            await Task.FromResult(_context.Books.Remove(book));
        }
        public async Task UpdateBookForAuthorAsync(Book book)
        {
            Book bookUpdate = await GetBookForAuthorAsync(book.AuthorId, book.BookId);
            if (bookUpdate != null)
            {
                bookUpdate.Title = book.Title;
                bookUpdate.Description = book.Description;
            }
        }
        public async Task<IEnumerable<Book>> GetBooksForAuthorAsync(Guid authorId)
        {
            return await _context.Books.Where(b => b.AuthorId == authorId).OrderBy(b => b.Title).ToListAsync();
        }
        public async Task<Book> GetBookForAuthorAsync(Guid authorId, Guid bookId)
        {
            return await _context.Books.Where(b => b.AuthorId == authorId && b.BookId == bookId).FirstOrDefaultAsync();
        }

        public Task<Book> UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            return Task.FromResult(book);
        }
    }
}
