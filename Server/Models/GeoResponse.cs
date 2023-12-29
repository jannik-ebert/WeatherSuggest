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

        public GeoResponse(string jsonResponse)
        {
            var jsonData = JArray.Parse(jsonResponse);

            if (jsonData.Count > 0)
            {
                var firstItem = jsonData[0];

                Name = firstItem.SelectToken("name")?.ToString() ?? string.Empty;
                Lat = double.TryParse(firstItem.SelectToken("lat")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var latResult) ? latResult : 0.0;
                Lon = double.TryParse(firstItem.SelectToken("lon")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var lonResult) ? lonResult : 0.0;
                Country = firstItem.SelectToken("country")?.ToString() ?? string.Empty;
                State = firstItem.SelectToken("state")?.ToString() ?? string.Empty;
            }
        }
    }
}
