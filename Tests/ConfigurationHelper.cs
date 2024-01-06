using Microsoft.Extensions.Configuration;

namespace Tests
{
    public class ConfigurationHelper
    {
        private static IConfigurationRoot _configuration;

        static ConfigurationHelper()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string GetApiKey()
        {
            return _configuration["ApiSettings:ApiKey"];
        }
    }
}
