using ECoffee.Persistence.Configurations;
using ECoffee.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECoffee.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ECoffeeDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));
        }
    }
}
