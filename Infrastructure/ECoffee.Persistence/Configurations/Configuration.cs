using Microsoft.Extensions.Configuration;

namespace ECoffee.Persistence.Configurations
{
    static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                try
                {
                    configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(),"../../Presentation/ECoffee.Api"));
                    configurationManager.AddJsonFile("appsettings.json");
                }
                catch
                {
                    configurationManager.AddJsonFile("appsettings.Production.json");
                }
                return configurationManager.GetConnectionString("MsSQL");

            }
        }
    }
}
