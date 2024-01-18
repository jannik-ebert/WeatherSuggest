using Newtonsoft.Json.Linq;
using System.Globalization;

namespace WeatherSuggest.Server.Models
{
    public class GeoResponse
    {
        public string? Name { get; }
        public double Lat { get; }
        public double Lon { get; }
        public string? Country { get; }
        public string? State { get; }

        public GeoResponse(JObject jsonResponse)
        {
            Name = jsonResponse.SelectToken("name")?.ToString() ?? string.Empty;
            Lat = double.TryParse(jsonResponse.SelectToken("lat")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var latResult) ? latResult : 0.0;
            Lon = double.TryParse(jsonResponse.SelectToken("lon")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var lonResult) ? lonResult : 0.0;
            Country = jsonResponse.SelectToken("country")?.ToString() ?? string.Empty;
            State = jsonResponse.SelectToken("state")?.ToString() ?? string.Empty;
        }
    }
}
