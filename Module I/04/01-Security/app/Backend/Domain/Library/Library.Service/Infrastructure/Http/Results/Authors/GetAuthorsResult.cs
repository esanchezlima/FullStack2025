using Library.Service.Application.Dtos;
using Library.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using Library.Service.Infrastructure.Persistence.Helpers.Paged;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Results.Authors
{
    public class GetAuthorsResult
    {
        public IEnumerable<ExpandoObject> ShapedAuthors { get; set; }
        public PaginationMetadata PaginationMetadata { get; set; }
        public LinkedCollectionResource LinkedCollectionResource { get; set; }
    }
}
