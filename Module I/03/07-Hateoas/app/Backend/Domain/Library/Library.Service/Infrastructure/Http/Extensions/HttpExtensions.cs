using Library.Service.Infrastructure.Http.Helpers.LinksBuilders;
using Library.Service.Infrastructure.Persistence.Helpers.DataMapping.TypeHelper;
using System.Text.Json;

namespace Library.Service.Infrastructure.Http.Extensions
{
    public static class HttpExtensions
    {
        public static void AddHttp(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen();
            services.AddScoped<ITypeHelperService, TypeHelperService>();
            services.AddScoped<IAuthorLinksBuilder, AuthorLinksBuilder>();
        }
    }
}
