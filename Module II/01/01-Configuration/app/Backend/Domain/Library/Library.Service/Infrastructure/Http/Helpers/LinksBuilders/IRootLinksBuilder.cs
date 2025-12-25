using Library.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using System.Collections.Generic;

namespace Library.Service.Infrastructure.Http.Helpers.LinksBuilders
{
    public interface IRootLinksBuilder
    {
        List<LinkDto> CreateDocumentationLinksForRoot();
    }
}