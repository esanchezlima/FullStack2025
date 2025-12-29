using Library.Service.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Results.Authors
{
    public class GetAuthorsResult
    {
        public List<AuthorDto> Authors { get; set; }
    }
}
