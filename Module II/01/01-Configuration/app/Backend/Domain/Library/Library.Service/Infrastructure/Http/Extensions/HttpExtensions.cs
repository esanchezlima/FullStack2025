using Library.Service.Infrastructure.Http.Helpers.LinksBuilders;
using Library.Service.Infrastructure.Persistence.Helpers.DataMapping.TypeHelper;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json;

namespace Library.Service.Infrastructure.Http.Extensions
{
    public static class HttpExtensions
    {
        public static void AddHttp(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddHttpContextAccessor();
            services.Configure<JsonOptions>(options => { options.SerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase; });
            services.AddSwaggerDocumentation();
            services.AddScoped<ITypeHelperService, TypeHelperService>();
            services.AddScoped<IAuthorLinksBuilder, AuthorLinksBuilder>();
            services.AddScoped<IBookLinksBuilder, BookLinksBuilder>();
            services.AddScoped<IRootLinksBuilder, RootLinksBuilder>();
        }
    }
}
