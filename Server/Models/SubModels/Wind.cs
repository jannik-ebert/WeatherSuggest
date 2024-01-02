using Newtonsoft.Json.Linq;
using System.Globalization;

namespace WeatherSuggest.Server.Models.SubModels
{
    public class Wind
    {
        public double Speed { get; }
        public int Deg { get; }
        public double Gust { get; }

        public Wind(JToken? windData)
        {
            if (windData is null)
                throw new ArgumentNullException(nameof(windData));

            Speed = double.TryParse(windData.SelectToken("speed")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var speedResult) ? speedResult : 0.0;
            Deg = int.TryParse(windData.SelectToken("deg")?.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture, out var degResult) ? degResult : 0;
            Gust = double.TryParse(windData.SelectToken("gust")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var gustResult) ? gustResult : 0.0;
        }
    }
}
