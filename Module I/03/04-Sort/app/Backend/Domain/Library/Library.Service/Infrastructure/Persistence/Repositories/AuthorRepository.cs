
using Library.Service.Application.Dtos;
using Library.Service.Domain.Authors.Entities;
using Library.Service.Domain.Authors.Interfaces;
using Library.Service.Infrastructure.Persistence.Contexts;
using Library.Service.Infrastructure.Persistence.Extensions;
using Library.Service.Infrastructure.Persistence.Helpers.DataMapping.ModelMapping;
using Microsoft.EntityFrameworkCore;

namespace Library.Service.Infrastructure.Persistence.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;
        private readonly IAuthorPropertyMappingService _authorPropertyMappingService;
        public AuthorRepository(
            LibraryContext context,
            IAuthorPropertyMappingService propertyMappingService
        )
        {
            _context = context;
            _authorPropertyMappingService = propertyMappingService;
        }
        public async Task<List<Author>> GetAuthorsAsync(AuthorsResourceParameters authorsResourceParameters)
        {            
            var queryAuthors = _context.Authors.ApplySort(authorsResourceParameters.OrderBy, _authorPropertyMappingService.GetPropertyMapping());


            if (!string.IsNullOrEmpty(authorsResourceParameters.Genre))
            {
                var genreForWhereClause = authorsResourceParameters.Genre.Trim().ToLower();
                queryAuthors = queryAuthors.Where(a => a.Genre.ToLower() == genreForWhereClause);
            }

            if (!string.IsNullOrEmpty(authorsResourceParameters.SearchQuery))
            {
                var searchQueryForWhereClause = authorsResourceParameters.SearchQuery.Trim().ToLower();

                queryAuthors = queryAuthors
                    .Where(a => a.Genre.ToLower().Contains(searchQueryForWhereClause)
                    || a.FirstName.ToLower().Contains(searchQueryForWhereClause)
                    || a.LastName.ToLower().Contains(searchQueryForWhereClause));
            }

            return queryAuthors.ToList();
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
