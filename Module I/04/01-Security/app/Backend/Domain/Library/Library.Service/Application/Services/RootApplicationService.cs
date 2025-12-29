using Library.Service.Application.Interfaces;
using Library.Service.Infrastructure.Http.Results.Root;

namespace Library.Service.Application.Services
{
    public partial class LibraryApplicationService : ILibraryApplicationService
    {        
        public GetRootResult GetRoot()
        {
            GetRootResult result = new GetRootResult();
            result.LinkedResources = _rootLinksBuilder.CreateDocumentationLinksForRoot();            
            return result;
        }
        public async Task<GetRootResult> GetRootAsync()
        {
            GetRootResult result = new GetRootResult();
            result.LinkedResources = await Task.FromResult(_rootLinksBuilder.CreateDocumentationLinksForRoot());
            return result;
        }

    }
}
