using Library.Service.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Http.Results.Authors
{
    public class GetAuthorByAuthorIdResult
    {
        public ExpandoObject ShapedAuthor { get; set; }
        public IDictionary<string, object> LinkedResource { get; set; }
    }
}
