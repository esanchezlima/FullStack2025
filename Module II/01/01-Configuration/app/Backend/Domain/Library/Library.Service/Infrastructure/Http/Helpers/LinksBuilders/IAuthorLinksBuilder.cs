using Library.Service.Domain.Authors.Entities;
using System.Dynamic;
using Library.Service.Application.Dtos;
using Library.Service.Application.Dtos;
using Library.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Library.Service.Infrastructure.Persistence.Helpers.Paged;

namespace Library.Service.Infrastructure.Http.Helpers.LinksBuilders
{
    public interface IAuthorLinksBuilder
    {
        string CreateAuthorsResourceUri(AuthorsResourceParameters authorsResourceParameters, ResourceUriType type);        
        PaginationMetadata GetPaginationMetadata(PagedList<Author> authors, AuthorsResourceParameters authorsResourceParameters);
        List<LinkDto> CreateDocumentationLinksForAuthor(Guid authorId, string fields);
        IEnumerable<IDictionary<string, object>> CreateDocumentationLinksForAuthorShapeData(IEnumerable<ExpandoObject> shapedAuthors, AuthorsResourceParameters authorsResourceParameters);
        IEnumerable<LinkDto> CreatePagedLinksForAuthors(AuthorsResourceParameters authorsResourceParameters, bool hasNext, bool hasPrevious);
    }
}