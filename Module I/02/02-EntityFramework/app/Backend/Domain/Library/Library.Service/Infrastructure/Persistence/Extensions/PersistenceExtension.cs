using Library.Service.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Library.Service.Infrastructure.Persistence.Extensions
{
    public class PersistenceOptions
    {
        public string ConnectionString { get; set; }        
    }

    public static class PersistenceExtension
    {        
        public static void AddPersistence(this IServiceCollection services, Action<PersistenceOptions> configure)
        {
            var options = new PersistenceOptions();
            configure(options);

            services.AddDbContext<LibraryContext>(o => o.UseSqlServer(options.ConnectionString));            
        }
    }
}
