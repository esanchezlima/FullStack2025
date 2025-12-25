using Library.Service.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Http.Results.Books
{
    public class GetBookForAuthorResult
    {
        public BookDto LinkedResource { get; set; }
    }
}
