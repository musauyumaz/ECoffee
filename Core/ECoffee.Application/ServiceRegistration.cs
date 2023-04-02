using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECoffee.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}
