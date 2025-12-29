using Library.Service.Domain.Authors.Entities;
using Library.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Http.Helpers.LinksBuilders
{
    public class RootLinksBuilder : IRootLinksBuilder
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LinkGenerator _linkGenerator;
        public RootLinksBuilder(
            LinkGenerator linkGenerator,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _httpContextAccessor = httpContextAccessor;
            _linkGenerator = linkGenerator;
        }
        public List<LinkDto> CreateDocumentationLinksForRoot()
        {            
            var links = new List<LinkDto>();
            links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "GetRoot", new { }), "self", "GET"));
            links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "GetAuthors", new { }), "authors", "GET"));
            links.Add(new LinkDto(_linkGenerator.GetUriByName(_httpContextAccessor.HttpContext, "CreateAuthor", new { }), "create_author", "POST"));

            return links;
        }
    }
}
