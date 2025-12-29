
using Library.Service.Domain.Authors.Entities;
using Library.Service.Domain.Authors.Interfaces;
using Library.Service.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Library.Service.Infrastructure.Persistence.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;        
        public AuthorRepository(
            LibraryContext context            
        )
        {
            _context = context;            
        }
        public async Task<List<Author>> GetAuthorsAsync()
        {
            var authors = _context.Authors.ToList();

            return authors;
        }
        public async Task<IEnumerable<Author>> GetAuthorsAsync(List<Guid> authorsIds)
        {
            return await _context.Authors.Where(a => authorsIds.Contains(a.AuthorId))
                .OrderBy(a => a.FirstName)
                .OrderBy(a => a.LastName)
                .ToListAsync();
        }
        public async Task AddAuthorAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
        }
        public async Task DeleteAuthorAsync(Author author)
        {
            await Task.FromResult(_context.Authors.Remove(author));
        }
        public async Task UpdateAuthorAsync(Author author)
        {
            var authorUpdate = await GetAuthorAsync(author.AuthorId);
            if (authorUpdate != null)
            {
                authorUpdate.FirstName = author.FirstName;
                authorUpdate.LastName = author.LastName;
                authorUpdate.Genre = author.Genre;
                authorUpdate.DateOfBirth = author.DateOfBirth;
                authorUpdate.DateOfDeath = author.DateOfDeath;
            }
        }
        public async Task<Author> GetAuthorAsync(Guid authorId)
        {
            return await _context.Authors.FirstOrDefaultAsync(a => a.AuthorId == authorId);
        }
        public async Task<bool> AuthorExists(Guid authorId)
        {
            return await _context.Authors.AnyAsync(a => a.AuthorId == authorId);
        }
    }
}
