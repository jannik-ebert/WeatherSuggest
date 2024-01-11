using Microsoft.Extensions.Options;
using WeatherSuggest.Server.Configuration;
using WeatherSuggest.Server.Models;
using WeatherSuggest.Server.Repositories;
using WeatherSuggest.Server.Services;

namespace Tests.BackendTests
{
    public class WeatherRepositoryTests
    {
        [Fact]
        public async Task GetWeatherDataAsync_ReturnsWeatherData_WhenCalledWithLatLon()
        {
            // Arrange
            var apiKey = ConfigurationHelper.GetApiKey();
            IOptions<ApiSettings> apiSettings = Options.Create<ApiSettings>(new ApiSettings(apiKey));
            var apiService = new ApiService(apiSettings);
            var weatherRepository = new WeatherRepository(apiService);

            // Act
            var result = await weatherRepository.GetWeatherDataAsync(52.5200, 13.4050);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<WeatherResponse>(result);
        }
    }
}
