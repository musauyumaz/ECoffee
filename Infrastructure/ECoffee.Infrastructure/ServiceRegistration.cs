using ECoffee.Application.Abstractions.Services;
using ECoffee.Infrastructure.Configurations;
using ECoffee.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECoffee.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailInfo>(configuration.GetSection("Mail"));
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
