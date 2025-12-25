using Library.Service.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Http.Results.AuthorCollections
{
    public class CreateAuthorCollectionResult
    {
        public IEnumerable<AuthorDto> AuthorsCollection { get; set; }
        public string AuhtorsIdsAsString { get; set; }
    }
}
