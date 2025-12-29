using AspNetCore.JsonPatch;
using Library.Service.Application.Dtos;
using Library.Service.Application.Interfaces;
using Library.Service.Domain.Authors.Entities;
using Library.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Library.Service.Infrastructure.Http.Results.Books;
using System.ComponentModel.DataAnnotations;

namespace Library.Service.Application.Services
{
    public partial class LibraryApplicationService : ILibraryApplicationService
    {        
        public async Task<GetBooksForAuthorResult> GetBooksForAuthorAsync(Guid authorId)
        {
            GetBooksForAuthorResult result = new GetBooksForAuthorResult();
            var booksForAuthorFromRepo = await _unitOfWork.Books.GetBooksForAuthorAsync(authorId);
            var booksForAuthor = _mapper.Map<IEnumerable<BookDto>>(booksForAuthorFromRepo);

            booksForAuthor = booksForAuthor.Select(book =>
            {
                book = _bookLinksBuilder.CreateDocumentationLinksForBook(book);
                return book;
            });

            var wrapper = new LinkedCollectionResourceWrapperDto<BookDto>(booksForAuthor);
            result.LinkedCollectionResource = _bookLinksBuilder.CreateDocumentationLinksForBooks(authorId, wrapper);

            return result;
        }
        public async Task<GetBookForAuthorResult> GetBookByBookIdForAuthorAsync(Guid authorId, Guid bookId)
        {
            GetBookForAuthorResult result = new GetBookForAuthorResult();
            var bookForAuthorFromRepo = await _unitOfWork.Books.GetBookForAuthorAsync(authorId, bookId);
            if (bookForAuthorFromRepo == null)
            {
                return null;
            }

            var bookForAuthor = _mapper.Map<BookDto>(bookForAuthorFromRepo);
            result.LinkedResource = _bookLinksBuilder.CreateDocumentationLinksForBook(bookForAuthor);

            return result;
        }
        public async Task<CreateBookForAuthorResult> CreateBookForAuthorAsync(Guid authorId, BookForCreationDto bookDto)
        {
            CreateBookForAuthorResult result = new CreateBookForAuthorResult();
            var bookEntity = _mapper.Map<Book>(bookDto);

            var validationResult = _validationService.ValidateBookCreation(bookDto);
            if (!validationResult.IsValid)
            {
                result.Success = false;
                result.ValidationErrors.AddRange(validationResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                return result;
            }

            await _unitOfWork.Books.AddBookForAuthorAsync(authorId, bookEntity);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Creating a book for author {authorId} failed on save.");
            }

            var bookToReturn = _mapper.Map<BookDto>(bookEntity);

            result.LinkedResource = _bookLinksBuilder.CreateDocumentationLinksForBook(bookToReturn);
            result.Success = true;

            return result;
        }

        public async Task<DeleteBookForAuthorResult> DeleteBookForAuthorAsync(Guid authorId, Guid bookId)
        {
            DeleteBookForAuthorResult result = new DeleteBookForAuthorResult();
            var bookForAuthorFromRepo = await _unitOfWork.Books.GetBookForAuthorAsync(authorId, bookId);
            if (bookForAuthorFromRepo == null)
            {
                return null;
            }

            await _unitOfWork.Books.DeleteBookAsync(bookForAuthorFromRepo);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Deleting book {bookId} for author {authorId} failed on save.");
            }

            result.Success = true;
            return result;
        }

        public async Task<UpdateBookForAuthorResult> UpdateBookForAuthorAsync(Guid authorId, Guid bookId, BookForUpdateDto bookDto)
        {
            UpdateBookForAuthorResult result = new UpdateBookForAuthorResult();
            var bookForAuthorFromRepo = await _unitOfWork.Books.GetBookForAuthorAsync(authorId, bookId);

            if (bookForAuthorFromRepo == null)
            {                
                var validationInsertResult = _validationService.ValidateBookUpdate(bookDto);

                if (!validationInsertResult.IsValid)
                {
                    result.Success = false;
                    result.ValidationErrors.AddRange(validationInsertResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                    return result;
                }

                var bookToAdd = _mapper.Map<Book>(bookDto);
                bookToAdd.BookId = bookId;
                await _unitOfWork.Books.AddBookForAuthorAsync(authorId, bookToAdd);

                if (!await _unitOfWork.SaveAsync())
                {
                    throw new Exception($"Upserting book {bookId} for author {authorId} failed on save.");
                }

                result.BookUpserted = _bookLinksBuilder.CreateDocumentationLinksForBook(_mapper.Map<BookDto>(bookToAdd));                
                result.Success = true;

                return result;
            }
                        
            var validationUpdateResult = _validationService.ValidateBookUpdate(bookDto);
            
            if (!validationUpdateResult.IsValid)
            {
                result.Success = false;
                result.ValidationErrors.AddRange(validationUpdateResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                return result;
            }

            _mapper.Map(bookDto, bookForAuthorFromRepo);
            await _unitOfWork.Books.UpdateBookForAuthorAsync(bookForAuthorFromRepo);

            if (!await _unitOfWork.SaveAsync())
            {
                throw new Exception($"Updating book {bookId} for author {authorId} failed on save.");
            }

            result.BookUpserted = _bookLinksBuilder.CreateDocumentationLinksForBook(_mapper.Map<BookDto>(bookForAuthorFromRepo));
            result.Success = true;
            return result;
        }

        public async Task<PartiallyUpdateBookForAuthorResult> PartiallyUpdateBookForAuthor(Guid authorId, Guid bookId, JsonPatchDocument<BookForUpdateDto> patchDoc)
        {
            PartiallyUpdateBookForAuthorResult result = new PartiallyUpdateBookForAuthorResult();
            var bookForAuthorFromRepo = await _unitOfWork.Books.GetBookForAuthorAsync(authorId, bookId);

            if (bookForAuthorFromRepo == null)
            {
                var bookDto = new BookForUpdateDto();
                patchDoc.ApplyTo(bookDto);
                              
                var validationResult = _validationService.ValidateBookUpdate(bookDto);
                if (!validationResult.IsValid)
                {
                    result.Success = false;
                    result.ValidationErrors.AddRange(validationResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                    return result;
                }

                var bookToAdd = _mapper.Map<Book>(bookDto);
                bookToAdd.BookId = bookId;

                await _unitOfWork.Books.AddBookForAuthorAsync(authorId, bookToAdd);

                if (!await _unitOfWork.SaveAsync())
                {
                    result.Success = false;
                    throw new Exception($"Upserting book {bookId} for author {authorId} failed on save.");
                }

                result.BookUpserted = _bookLinksBuilder.CreateDocumentationLinksForBook(_mapper.Map<BookDto>(bookToAdd));
                result.Success = true;

                return result;
            }

            var bookToPatch = _mapper.Map<BookForUpdateDto>(bookForAuthorFromRepo);
            patchDoc.ApplyTo(bookToPatch);
                        
            var patchValidationResult = _validationService.ValidateBookUpdate(bookToPatch);
            if (!patchValidationResult.IsValid)
            {
                result.Success = false;
                result.ValidationErrors.AddRange(patchValidationResult.Errors.Select(e => new ValidationResult(e.ErrorMessage)));
                return result;
            }

            _mapper.Map(bookToPatch, bookForAuthorFromRepo);
            await _unitOfWork.Books.UpdateBookForAuthorAsync(bookForAuthorFromRepo);

            if (!await _unitOfWork.SaveAsync())
            {
                result.Success = false;
                throw new Exception($"Patching book {bookId} for author {authorId} failed on save.");
            }

            result.BookUpserted = _bookLinksBuilder.CreateDocumentationLinksForBook(_mapper.Map<BookDto>(bookForAuthorFromRepo));
            result.Success = true;
            return result;
        }
    }
}
