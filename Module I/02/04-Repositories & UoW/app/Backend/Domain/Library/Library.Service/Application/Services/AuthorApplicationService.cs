using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Service.Application.Interfaces;
using Library.Service.Application.Dtos;

namespace Library.Service.Application.Services
{
    public partial class LibraryApplicationService : ILibraryApplicationService
    {   
        public async Task<List<AuthorDto>> GetAuthorsAsync()
        {            
            var authorsFromRepo = await _unitOfWork.Authors.GetAuthorsAsync();
            var authors = _mapper.Map<List<AuthorDto>>(authorsFromRepo);
            
            return authors;
        }
       
    }
}
