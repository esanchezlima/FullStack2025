using Library.Service.Domain.Authors.Interfaces;
using Library.Service.Domain.Authors.Services;

namespace Library.Service.Domain.Extensions
{
    public static class DomainExtensions
    {
        public static void AddDomain(this IServiceCollection services)
        {            
            services.AddScoped<IAuthorDomainService, AuthorDomainService>();
        }
    }
}
