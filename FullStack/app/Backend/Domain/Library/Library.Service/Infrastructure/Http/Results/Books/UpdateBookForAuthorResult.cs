using Library.Service.Application.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Service.Infrastructure.Http.Results.Books
{
    public class UpdateBookForAuthorResult
    {
        public BookDto BookUpserted { get; set; }
        public List<ValidationResult> ValidationErrors { get; set; } = new();
        public bool Success { get; set; }
    }
}
