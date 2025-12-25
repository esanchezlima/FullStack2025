using Library.Service.Application.Dtos;
using Library.Service.Application.Interfaces;
using Library.Service.Domain.Authors.Entities;
using Library.Service.Infrastructure.Http.Results.AuthorCollections;

namespace Library.Service.Application.Services
{
    public partial class LibraryApplicationService : ILibraryApplicationService
    {        
        public async Task<GetAuthorCollectionResult> GetAuthorsCollectionAsync(List<Guid> authorsIds)
        {
            GetAuthorCollectionResult result = new GetAuthorCollectionResult();
            var authorsEntities = await _unitOfWork.Authors.GetAuthorsAsync(authorsIds);

            if (!authorsEntities.Any())
            {
                result.AuthorsFound = false;
                return result;
            }

            result.AuthorsFound = true;
            result.AuthorCollection = _mapper.Map<IEnumerable<AuthorDto>>(authorsEntities);

            return result;
        }
        public async Task<CreateAuthorCollectionResult> CreateAuthorCollectionAsync(IEnumerable<AuthorForCreationDto> authorCollection)
        {
            CreateAuthorCollectionResult result = new CreateAuthorCollectionResult();
            var authorEntities = _mapper.Map<IEnumerable<Author>>(authorCollection);

            foreach (var author in authorEntities)
            {
                await _unitOfWork.Authors.AddAuthorAsync(author);
            }

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception("Creating an author collection failed on save.");
            }

            result.AuthorsCollection = _mapper.Map<IEnumerable<AuthorDto>>(authorEntities);
            result.AuhtorsIdsAsString = string.Join(",", result.AuthorsCollection.Select(a => a.AuthorId));

            return result;
        }
    }
}
