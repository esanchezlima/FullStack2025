using Library.Service.Application.Dtos;
using Library.Service.Domain.Authors.Entities;
using Library.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Http.Helpers.LinksBuilders
{
    public class BookLinksBuilder : IBookLinksBuilder
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LinkGenerator _linkGenerator;

        public BookLinksBuilder(
            LinkGenerator linkGenerator,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
        }
        public BookDto CreateDocumentationLinksForBook(BookDto book)
        {
            book.Links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "GetBookForAuthor", new { authorId = book.AuthorId, bookId = book.BookId }), "self", "GET"));
            book.Links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "DeleteBookForAuthor", new { authorId = book.AuthorId, bookId = book.BookId }), "delete_book", "DELETE"));
            book.Links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "UpdateBookForAuthor", new { authorId = book.AuthorId, bookId = book.BookId }), "update_book", "PUT"));
            book.Links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "PartiallyUpdateBookForAuthor", new { authorId = book.AuthorId, bookId = book.BookId }), "partially_update_book", "PATCH"));

            return book;
        }

        public LinkedCollectionResourceWrapperDto<BookDto> CreateDocumentationLinksForBooks(Guid authorId, LinkedCollectionResourceWrapperDto<BookDto> booksWrapper)
        {
            booksWrapper.Links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "GetBooksForAuthor", new { authorId }), "self", "GET"));

            return booksWrapper;
        }
    }
}
