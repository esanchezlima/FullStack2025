using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service.Application.Dtos
{
    public abstract class BookForManipulationDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
