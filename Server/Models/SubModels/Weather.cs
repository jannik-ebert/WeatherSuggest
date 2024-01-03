using Newtonsoft.Json.Linq;
using System.Globalization;

namespace WeatherSuggest.Server.Models.SubModels
{
    public class Weather
    {
        public int ID { get; }
        public string? Main { get; }
        public string? Description { get; }

        public Weather(JToken? weatherData)
        {
            if (weatherData is null)
                throw new ArgumentNullException(nameof(weatherData));

            ID = int.TryParse(weatherData.SelectToken("id")?.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture, out var idResult) ? idResult : 0;
            Main = weatherData.SelectToken("main")?.ToString() ?? string.Empty;
            Description = weatherData.SelectToken("description")?.ToString() ?? string.Empty;
        }
    }
}
