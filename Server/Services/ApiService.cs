using Microsoft.Extensions.Options;
using WeatherSuggest.Server.Configuration;

namespace WeatherSuggestions.Server.Services 
{
    public class ApiService
    {
        private readonly ApiSettings _apiSettings;

        public ApiService(IOptions<ApiSettings> apiSettings)
        {
            _apiSettings = apiSettings.Value;
        }

        public string? GetApiKey()
        {
            return _apiSettings.ApiKey;
        }
    }
}