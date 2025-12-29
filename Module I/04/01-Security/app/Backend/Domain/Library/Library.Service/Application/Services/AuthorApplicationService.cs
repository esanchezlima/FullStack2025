using Library.Service.Application.Dtos;
using Library.Service.Application.Interfaces;
using Library.Service.Domain.Authors.Entities;
using Library.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Library.Service.Infrastructure.Http.Results.Authors;
using Library.Service.Infrastructure.Persistence.Extensions;
using Library.Service.Infrastructure.Results.Authors;
using System.ComponentModel.DataAnnotations;

namespace Library.Service.Application.Services
{
    public partial class LibraryApplicationService : ILibraryApplicationService
    {   
        public async Task<GetAuthorsResult> GetAuthorsAsync(AuthorsResourceParameters authorsResourceParameters)
        {
            GetAuthorsResult result = new();
            _validationService.ValidateAuthorsResourceParameters(authorsResourceParameters);
            var authorsFromRepo = await _unitOfWork.Authors.GetAuthorsAsync(authorsResourceParameters);
            var authors = _mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo);
            result.ShapedAuthors = authors.ShapeData(authorsResourceParameters.Fields);
            result.PaginationMetadata = _authorLinksBuilder.GetPaginationMetadata(authorsFromRepo, authorsResourceParameters);

            var links = _authorLinksBuilder.CreatePagedLinksForAuthors(authorsResourceParameters, authorsFromRepo.HasNext, authorsFromRepo.HasPrevious);
            var shapedAuthorsWithLinks = _authorLinksBuilder.CreateDocumentationLinksForAuthorShapeData(result.ShapedAuthors, authorsResourceParameters);
            result.LinkedCollectionResource = new LinkedCollectionResource { Value = shapedAuthorsWithLinks };
            
            return result;
        }
        public async Task<GetAuthorByAuthorIdResult> GetAuthorByAuthorIdAsync(Guid authorId, string fields)
        {
            GetAuthorByAuthorIdResult result = new();
            var authorFromRepo = await _unitOfWork.Authors.GetAuthorAsync(authorId);

            if (authorFromRepo == null)
            {
                return null;
            }

            var author = _mapper.Map<AuthorDto>(authorFromRepo);
            result.ShapedAuthor = author.ShapeData(fields);

            var links = _authorLinksBuilder.CreateDocumentationLinksForAuthor(authorId, fields);
            result.LinkedResource = new Dictionary<string, object>(result.ShapedAuthor);
            result.LinkedResource.Add("links", links);

            return result;
        }
        public async Task<CreateAuthorResult> CreateAuthorAsync(AuthorForCreationDto author)
        {   
            CreateAuthorResult result = new();
            var validationResult = _validationService.ValidateAuthorCreation(author);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.ValidationErrors.AddRange(validationResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                return result;
            }

            var authorEntity = _mapper.Map<Author>(author);
            await _unitOfWork.Authors.AddAuthorAsync(authorEntity);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception("Creating an author failed on save.");
            }

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
            result.ShapedAuthor = authorToReturn.ShapeData(null);
            result.Success = true;

            var links = _authorLinksBuilder.CreateDocumentationLinksForAuthor(authorToReturn.AuthorId, null);
            result.LinkedResource = new Dictionary<string, object>(result.ShapedAuthor);
            result.LinkedResource.Add("links", links);

            return result;
        }
        public async Task<CreateAuthorWithDateOfDeathResult> CreateAuthorWithDateOfDeathAsync(AuthorForCreationWithDateOfDeathDto author)
        {
            CreateAuthorWithDateOfDeathResult result = new();
            var validationResult = _validationService.ValidateAuthorCreationWithDateOfDeath(author);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.ValidationErrors.AddRange(validationResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                return result;
            }

            var authorEntity = _mapper.Map<Author>(author);
            await _unitOfWork.Authors.AddAuthorAsync(authorEntity);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception("Creating an author failed on save");
            }

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
            result.ShapedAuthor = authorToReturn.ShapeData(null);

            var links = _authorLinksBuilder.CreateDocumentationLinksForAuthor(authorToReturn.AuthorId, null);
            result.LinkedResource = new Dictionary<string, object>(result.ShapedAuthor);
            result.LinkedResource.Add("links", links);

            return result;
        }
        public async Task<bool?> DeleteAuthorAsync(Guid authorId)
        {
            var authorFronRepo = await _unitOfWork.Authors.GetAuthorAsync(authorId);
            if (authorFronRepo == null)
            {
                return null;
            }

            await _unitOfWork.Authors.DeleteAuthorAsync(authorFronRepo);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Deleting author {authorId} failed on save.");
            }

            return true;
        }
        public async Task<UpdateAuthorResult> UpdateAuthorAsync(Guid authorId, AuthorForUpdateDto author)
        {
            UpdateAuthorResult result = new();
            var validationResult = _validationService.ValidateAuthorUpdate(author);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.ValidationErrors.AddRange(validationResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                return result;
            }

            var authorFromRepo = await _unitOfWork.Authors.GetAuthorAsync(authorId);
            if (authorFromRepo == null)
            {
                var authorToAdd = _mapper.Map<Author>(author);
                authorToAdd.AuthorId = authorId;

                await _unitOfWork.Authors.AddAuthorAsync(authorToAdd);

                if (!await _unitOfWork.SaveAsync())
                {
                    throw new Exception($"Upserting author {authorId} failed on save.");
                }

                result.AuthorUpserted = _mapper.Map<AuthorDto>(authorToAdd);
                result.Success = true;

                return result;
            }

            _mapper.Map(author, authorFromRepo);
            await _unitOfWork.Authors.UpdateAuthorAsync(authorFromRepo);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Updating author {authorId} failed on save.");
            }

            result.Success = true;
            return result;
        }
        public async Task<bool> AuthorExistsAsync(Guid authorId)
        {
            return await _unitOfWork.Authors.AuthorExists(authorId);
        }
    }
}
