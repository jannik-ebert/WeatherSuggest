using BlazorBootstrap;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using WeatherSuggest.Client.Components;
using WeatherSuggest.Shared.DTOs;

namespace Tests.FrontendTests
{
    public class LocationCardTests
    {
        [Fact]
        public void LocationCard_ShouldDisplayLocationInfo_WhenLocationIsNotNull()
        {
            // Arrange
            var location = new GeoResponseDto("Berlin", 52.5200, 13.4050, "Germany", "Berlin");

            using var ctx = new TestContext();
            ctx.Services.AddSingleton<BootstrapIconProvider>();
            ctx.Services.AddSingleton<BootstrapClassProvider>();
            ctx.Services.AddSingleton<IIdGenerator, MockIdGenerator>();
            var cut = ctx.RenderComponent<LocationCard>(parameters => parameters
                .Add(p => p.Location, location));

            // Act
            var locationName = cut.Find("h3").TextContent;
            var paragraphs = cut.FindAll("p").ToList();
            var country = paragraphs[0].TextContent;
            var state = paragraphs[1].TextContent;

            // Assert
            Assert.Equal("Berlin", locationName);
            Assert.Equal(" Country: Germany", country);
            Assert.Equal(" State: Berlin", state);
        }
    }
}
