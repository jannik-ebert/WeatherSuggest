using BlazorBootstrap;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using WeatherSuggest.Client.Components;
using WeatherSuggest.Shared.DTOs;

namespace Tests.FrontendTests
{
    public class WeatherCardTests : TestContext
    {
        [Fact]
        public void WeatherCard_ShouldDisplayWeatherInfo_WhenWeatherDataIsNotNull()
        {
            // Arrange
            WeatherResponseDto weatherData = GenerateWRDto();

            using var ctx = new TestContext();
            ctx.Services.AddSingleton<BootstrapIconProvider>();
            ctx.Services.AddSingleton<BootstrapClassProvider>();
            ctx.Services.AddSingleton<IIdGenerator, MockIdGenerator>();
            var cut = ctx.RenderComponent<WeatherCard>(parameters => parameters.Add(p => p.WeatherData, weatherData));

            // Act
            var locationText = cut.Find(".location").TextContent;
            var cityName = locationText.Split(',')[0].Trim();
            var temperature = cut.Find(".weather-temp").TextContent;
            var paragraphs = cut.FindAll(".value").ToList();
            var windSpeed = paragraphs[2].TextContent;
            var cloudiness = paragraphs[3].TextContent;

            // Assert
            Assert.Equal("New York", cityName);
            Assert.Equal("25 °C", temperature);
            Assert.Equal("7,2 km / h", windSpeed);
            Assert.Equal("30 %", cloudiness);
        }

        private static WeatherResponseDto GenerateWRDto()
        {
            return new WeatherResponseDto(
                Coord: new CoordDto(Lon: -74.006, Lat: 40.7128),
                Weather: new List<WeatherDto>
                {
                    new WeatherDto(ID: 800, Main: "Clear", Description: "clear sky")
                },
                Base: "stations",
                Main: new MainDto(
                    Temp: 25,
                    FeelsLike: 26.8,
                    Pressure: 1012,
                    Humidity: 50,
                    TempMin: 24.0,
                    TempMax: 27.0,
                    GrndLevel: 1010
                ),
                Visibility: 10000,
                Wind: new WindDto(Speed: 2, Deg: 120, Gust: 4.0),
                Clouds: new CloudsDto(All: 30),
                Rain: new RainDto(H1: 0.0, H3: 0.0),
                Snow: new SnowDto(H1: 0.0, H3: 0.0),
                Dt: DateTime.UtcNow,
                Sys: new SysDto(Country: "US", Sunrise: DateTime.UtcNow.AddHours(-5), Sunset: DateTime.UtcNow.AddHours(5)),
                Timezone: "-0500",
                ID: 5128581,
                Name: "New York"
            );
        }
    }

    public class MockIdGenerator : IIdGenerator
    {
        public string GenerateUniqueId() => Guid.NewGuid().ToString();

        string IIdGenerator.GetNextId()
        {
            throw new NotImplementedException();
        }
    }
}
