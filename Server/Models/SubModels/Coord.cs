using Newtonsoft.Json.Linq;
using System.Globalization;

namespace WeatherSuggest.Server.Models.SubModels
{
    public class Coord
    {
        public double Lon { get; }
        public double Lat { get; }

        public Coord(JToken? coordData)
        {
            if (coordData is null)
                throw new ArgumentNullException(nameof(coordData));

            Lon = double.TryParse(coordData.SelectToken("lon")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var lonResult) ? lonResult : 0.0;
            Lat = double.TryParse(coordData.SelectToken("lat")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var latResult) ? latResult : 0.0;
        }
    }
}
