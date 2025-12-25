using Library.Service.Domain.Authors.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Library.Service.Application.Dtos;
using Library.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Library.Service.Infrastructure.Persistence.Helpers.Paged;

namespace Library.Service.Infrastructure.Http.Helpers.LinksBuilders
{
    public class AuthorLinksBuilder : IAuthorLinksBuilder
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LinkGenerator _linkGenerator;

        public AuthorLinksBuilder(
            LinkGenerator linkGenerator,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
        }

        public string CreateAuthorsResourceUri(AuthorsResourceParameters authorsResourceParameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return _linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "GetAuthors",
                      new
                      {
                          fields = authorsResourceParameters.Fields,
                          orderBy = authorsResourceParameters.OrderBy,
                          searchQuery = authorsResourceParameters.SearchQuery,
                          genre = authorsResourceParameters.Genre,
                          pageNumber = authorsResourceParameters.PageNumber - 1,
                          pageSize = authorsResourceParameters.PageSize
                      });
                case ResourceUriType.NextPage:
                    return _linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "GetAuthors",
                      new
                      {
                          fields = authorsResourceParameters.Fields,
                          orderBy = authorsResourceParameters.OrderBy,
                          searchQuery = authorsResourceParameters.SearchQuery,
                          genre = authorsResourceParameters.Genre,
                          pageNumber = authorsResourceParameters.PageNumber + 1,
                          pageSize = authorsResourceParameters.PageSize
                      });
                case ResourceUriType.Current:
                default:
                    return _linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "GetAuthors",
                    new
                    {
                        fields = authorsResourceParameters.Fields,
                        orderBy = authorsResourceParameters.OrderBy,
                        searchQuery = authorsResourceParameters.SearchQuery,
                        genre = authorsResourceParameters.Genre,
                        pageNumber = authorsResourceParameters.PageNumber,
                        pageSize = authorsResourceParameters.PageSize
                    });
            }
        }
        public PaginationMetadata GetPaginationMetadata(PagedList<Author> authors, AuthorsResourceParameters authorsResourceParameters)
        {
            PaginationMetadata paginationMetadata = new()
            {
                PreviousPageLink = authors.HasPrevious ? CreateAuthorsResourceUri(authorsResourceParameters, ResourceUriType.PreviousPage) : null,
                NextPageLink = authors.HasNext ? CreateAuthorsResourceUri(authorsResourceParameters, ResourceUriType.NextPage) : null,
                TotalCount = authors.TotalCount,
                PageSize = authors.PageSize,
                CurrentPage = authors.CurrentPage,
                TotalPages = authors.TotalPages,
            };

            return paginationMetadata;
        }
        public IEnumerable<LinkDto> CreatePagedLinksForAuthors(AuthorsResourceParameters authorsResourceParameters, bool hasNext, bool hasPrevious)
        {
            var links = new List<LinkDto>
            {
                // self 
                new LinkDto(CreateAuthorsResourceUri(authorsResourceParameters, ResourceUriType.Current), "self", "GET")
            };

            if (hasNext)
            {
                links.Add(new LinkDto(CreateAuthorsResourceUri(authorsResourceParameters, ResourceUriType.NextPage), "nextPage", "GET"));
            }

            if (hasPrevious)
            {
                links.Add(new LinkDto(CreateAuthorsResourceUri(authorsResourceParameters, ResourceUriType.PreviousPage), "previousPage", "GET"));
            }

            return links;
        }
        public IEnumerable<IDictionary<string, object>> CreateDocumentationLinksForAuthorShapeData(IEnumerable<ExpandoObject> shapedAuthors, AuthorsResourceParameters authorsResourceParameters)
        {
            var shapedAuthorsWithLinks = shapedAuthors.Select(author =>
            {
                IDictionary<string, object> authorAsDictionary = new Dictionary<string, object>((author as IDictionary<string, object>));
                var authorLinks = CreateDocumentationLinksForAuthor((Guid)authorAsDictionary["AuthorId"], authorsResourceParameters.Fields);
                authorAsDictionary.Add("links", authorLinks);

                return authorAsDictionary;
            });

            return shapedAuthorsWithLinks.ToList();
        }
        public List<LinkDto> CreateDocumentationLinksForAuthor(Guid authorId, string fields)
        {
            var links = new List<LinkDto>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "GetAuthor", new { authorId }), "self", "GET"));
            }
            else
            {
                links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "GetAuthor", new { authorId, fields }), "self", "GET"));
            }

            links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "DeleteAuthor", new { authorId }), "delete_author", "DELETE"));
            links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "UpdateAuthor", new { authorId }), "update_author", "PUT"));

            return links;
        }
    }
}
