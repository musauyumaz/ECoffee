using Microsoft.Extensions.Configuration;

namespace ECoffee.Persistence.Configurations
{
    public static class Configuration
    {
        private static IConfiguration _configuration;

        public static void Configure(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string ConnectionString => _configuration.GetConnectionString("MsSQL");

    }
}
