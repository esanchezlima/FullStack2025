using Library.Service.Infrastructure.Http.Extensions;
using Library.Service.Infrastructure.Persistence.Extensions;

namespace Library.Service.Infrastructure.Extensions
{
    public class InfrastructureOptions
    {
        public string ConnectionString { get; set; }        
    }
    public static class InfrastructureExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, Action<InfrastructureOptions> configure)
        {
            var options = new InfrastructureOptions();
            configure(options);

            services.AddHttp();
            services.AddPersistence(opt=>opt.ConnectionString = options.ConnectionString);            
        }
    }
}
