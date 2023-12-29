using Newtonsoft.Json.Linq;
using WeatherSuggest.Server.Models;
using WeatherSuggestions.Server.Services;

namespace WeatherSuggest.Server.Repositories
{
    public class LocationsRepository : ILocationsRepository
    {
        private readonly ApiService _apiService;
        private string? _apiKey;

        public LocationsRepository(ApiService apiService)
        {
            _apiService = apiService;
            _apiKey = _apiService.GetApiKey();
        }

        public async Task<IEnumerable<GeoResponse>?> GetLocationsAsync(string cityName)
        {
            List<GeoResponse>? locations = new();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetStringAsync($"http://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit=5&appid={_apiKey}");

                var jsonData = JArray.Parse(response);

                locations = jsonData.Select(json => new GeoResponse((JObject)json)).ToList();
            }

            return locations;
        }
    }
}
