using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Application.Dtos
{
    public class AuthorForUpdateDto
    {
        public AuthorForUpdateDto()
        {
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Genre { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }

    }
}
