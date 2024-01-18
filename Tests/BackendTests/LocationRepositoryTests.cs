using Microsoft.Extensions.Options;
using WeatherSuggest.Server.Configuration;
using WeatherSuggest.Server.Models;
using WeatherSuggest.Server.Repositories;
using WeatherSuggest.Server.Services;

namespace Tests.BackendTests
{
    public class LocationRepositoryTests
    {
        [Fact]
        public async Task GetLocationsAsync_ReturnsLocations_WhenCalledWithCityName()
        {
            // Arrange
            var apiKey = ConfigurationHelper.GetApiKey();
            IOptions<ApiSettings> apiSettings = Options.Create<ApiSettings>(new ApiSettings(apiKey));
            var apiService = new ApiService(apiSettings);
            var locationRepository = new LocationsRepository(apiService);

            // Act
            var result = await locationRepository.GetLocationsAsync("Berlin");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.IsAssignableFrom<IEnumerable<GeoResponse>>(result);
        }
    }
}
