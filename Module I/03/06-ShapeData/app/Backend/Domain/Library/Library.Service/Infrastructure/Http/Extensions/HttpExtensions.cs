using Library.Service.Infrastructure.Persistence.Helpers.DataMapping.TypeHelper;
using System.Text.Json;

namespace Library.Service.Infrastructure.Http.Extensions
{
    public static class HttpExtensions
    {
        public static void AddHttp(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<ITypeHelperService, TypeHelperService>();
        }
    }
}
