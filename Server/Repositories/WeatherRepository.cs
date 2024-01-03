using Newtonsoft.Json.Linq;
using WeatherSuggest.Server.Models;
using WeatherSuggestions.Server.Services;

namespace WeatherSuggest.Server.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly ApiService _apiService;
        private string? _apiKey;

        public WeatherRepository(ApiService apiService)
        {
            _apiService = apiService;
            _apiKey = _apiService.GetApiKey();
        }

        public async Task<WeatherResponse> GetWeatherDataAsync(double lat, double lon)
        {
            WeatherResponse weatherData;

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={_apiKey}&units=metric");

                var jsonData = JObject.Parse(response);

                weatherData = new WeatherResponse(jsonData);
            }

            return weatherData;
        }
    }
}
