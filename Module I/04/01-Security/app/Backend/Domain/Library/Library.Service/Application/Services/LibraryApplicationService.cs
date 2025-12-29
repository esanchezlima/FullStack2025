using AutoMapper;
using Library.Service.Application.Interfaces;
using Library.Service.Infrastructure.Http.Helpers.LinksBuilders;
using Library.Service.Infrastructure.Persistence.UnitOfWork;

namespace Library.Service.Application.Services
{
    public partial class LibraryApplicationService : ILibraryApplicationService
    {
        private readonly LibraryUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidationService _validationService;
        private readonly IAuthorLinksBuilder _authorLinksBuilder;
        private readonly IBookLinksBuilder _bookLinksBuilder;
        private readonly IRootLinksBuilder _rootLinksBuilder;

        public LibraryApplicationService(
            LibraryUnitOfWork unitOfWork,
            IMapper mapper,
            IAuthorLinksBuilder authorLinksBuilder,
            IBookLinksBuilder bookLinksBuilder,
            IRootLinksBuilder rootLinksBuilder,
            IValidationService validationService
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authorLinksBuilder = authorLinksBuilder;
            _bookLinksBuilder = bookLinksBuilder;
            _rootLinksBuilder = rootLinksBuilder;
            _validationService = validationService;
        }
    }
}
