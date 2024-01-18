using WeatherSuggest.Server.Models;

namespace WeatherSuggest.Server.Repositories
{
    public interface ILocationsRepository
    {
        public Task<IEnumerable<GeoResponse>?> GetLocationsAsync(string cityName);
    }
}
