using Library.Service.Application.Dtos;
using Library.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;

namespace Library.Service.Infrastructure.Http.Helpers.LinksBuilders
{
    public interface IBookLinksBuilder
    {
        BookDto CreateDocumentationLinksForBook(BookDto book);
        LinkedCollectionResourceWrapperDto<BookDto> CreateDocumentationLinksForBooks(Guid authorId, LinkedCollectionResourceWrapperDto<BookDto> booksWrapper);
    }
}