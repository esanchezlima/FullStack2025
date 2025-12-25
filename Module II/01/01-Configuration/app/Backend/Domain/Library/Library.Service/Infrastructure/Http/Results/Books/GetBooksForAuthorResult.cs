using Library.Service.Application.Dtos;
using Library.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Http.Results.Books
{
    public class GetBooksForAuthorResult
    {
        public LinkedCollectionResourceWrapperDto<BookDto> LinkedCollectionResource { get; set; }
    }
}
