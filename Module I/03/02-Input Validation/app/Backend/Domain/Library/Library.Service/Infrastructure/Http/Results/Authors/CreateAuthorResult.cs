using Library.Service.Application.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Http.Results.Authors
{
    public class CreateAuthorResult
    {
        public AuthorDto Author { get; set; }
        public List<ValidationResult> ValidationErrors { get; set; } = new();
        public bool Success { get; set; }
    }
}
