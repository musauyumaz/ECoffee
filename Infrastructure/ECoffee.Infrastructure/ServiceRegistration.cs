using ECoffee.Application.Abstractions.Services;
using ECoffee.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ECoffee.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
