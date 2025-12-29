using AutoMapper;
using Library.Service.Application.Interfaces;
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

        public LibraryApplicationService(
            LibraryUnitOfWork unitOfWork,
            IMapper mapper,
            IValidationService validationService
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validationService = validationService;
        }
    }
}
