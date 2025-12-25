using Library.Service.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Http.Results.AuthorCollections
{
    public class GetAuthorCollectionResult
    {
        public IEnumerable<AuthorDto> AuthorCollection { get; set; }
        public bool AuthorsFound { get; set; }
    }
}
