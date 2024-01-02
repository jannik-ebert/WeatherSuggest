using WeatherSuggest.Server.Models;

namespace WeatherSuggest.Server.Repositories
{
    public interface IWeatherRepository
    {
        public Task<WeatherResponse> GetWeatherDataAsync(double lat, double lon);
    }
}
