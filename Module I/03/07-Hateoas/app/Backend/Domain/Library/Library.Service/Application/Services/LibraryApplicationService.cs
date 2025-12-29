using AutoMapper;
using Library.Service.Application.Interfaces;
using Library.Service.Infrastructure.Http.Helpers.LinksBuilders;
using Library.Service.Infrastructure.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Service.Application.Services
{
    public partial class LibraryApplicationService : ILibraryApplicationService
    {
        private readonly LibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;
        private readonly IAuthorLinksBuilder _authorLinksBuilder;

        public LibraryApplicationService(
            LibraryUnitOfWork unitOfWork,
            IMapper mapper,
            IAuthorLinksBuilder authorLinksBuilder,
            IValidationService validationService
        )
        {
            _unitOfWork = unitOfWork;            
            _mapper = mapper;
            _authorLinksBuilder = authorLinksBuilder;
            _validationService = validationService;
        }
    }
}
