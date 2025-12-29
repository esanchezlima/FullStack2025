using Library.Service.Infrastructure.Http.Helpers.LinksBuilders.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Application.Dtos
{
    public class BookDto : LinkedResourceBaseDto
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
    }
}
