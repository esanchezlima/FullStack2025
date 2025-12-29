using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Service.Application.Interfaces;
using Library.Service.Application.Dtos;
using Library.Service.Domain.Authors.Entities;
using Library.Service.Infrastructure.Http.Results.Authors;

namespace Library.Service.Application.Services
{
    public partial class LibraryApplicationService : ILibraryApplicationService
    {   
        public async Task<List<AuthorDto>> GetAuthorsAsync()
        {            
            var authorsFromRepo = await _unitOfWork.Authors.GetAuthorsAsync();
            var authors = _mapper.Map<List<AuthorDto>>(authorsFromRepo);
            
            return authors;
        }
        public async Task<AuthorDto> GetAuthorByAuthorIdAsync(Guid authorId)
        {
            var authorFromRepo = await _unitOfWork.Authors.GetAuthorAsync(authorId);

            if (authorFromRepo == null)
            {
                return null;
            }

            var author = _mapper.Map<AuthorDto>(authorFromRepo);
            return author;
        }
        public async Task<AuthorDto> CreateAuthorAsync(AuthorForCreationDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);

            await _unitOfWork.Authors.AddAuthorAsync(authorEntity);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception("Creating an author failed on save.");
            }

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
            return authorToReturn;
        }
        public async Task<AuthorDto> CreateAuthorWithDateOfDeathAsync(AuthorForCreationWithDateOfDeathDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);

            await _unitOfWork.Authors.AddAuthorAsync(authorEntity);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception("Creating an author failed on save");
            }

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
            return authorToReturn;
        }
        public async Task<bool?> DeleteAuthorAsync(Guid authorId)
        {
            var authorFromRepo = await _unitOfWork.Authors.GetAuthorAsync(authorId);
            if (authorFromRepo == null)
            {
                return null;
            }

            await _unitOfWork.Authors.DeleteAuthorAsync(authorFromRepo);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Deleting author {authorId} failed on save.");
            }

            return true;
        }
        public async Task<UpdateAuthorResult> UpdateAuthorAsync(Guid authorId, AuthorForUpdateDto author)
        {
            UpdateAuthorResult result = new();
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
