using Library.Service.Application.Interfaces;
using Library.Service.Application.Mappers;
using Library.Service.Application.Services;

namespace Library.Service.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AuthorMapper));            
            services.AddScoped<ILibraryApplicationService, LibraryApplicationService>();

        }
    }
}
