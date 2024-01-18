using Newtonsoft.Json.Linq;
using System.Globalization;

namespace WeatherSuggest.Server.Models.SubModels
{
    public class Rain
    {
        public double H1 { get; }
        public double H3 { get; }

        public Rain(JToken? rainData)
        {
            if (rainData is null)
                throw new ArgumentNullException(nameof(rainData));

            H1 = double.TryParse(rainData.SelectToken("1h")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var h1Result) ? h1Result : 0.0;
            H3 = double.TryParse(rainData.SelectToken("3h")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var h3Result) ? h3Result : 0.0;
        }
    }
}
