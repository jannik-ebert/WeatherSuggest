using Newtonsoft.Json.Linq;
using System.Globalization;

namespace WeatherSuggest.Server.Models.SubModels
{
    public class Snow
    {
        public double H1 { get; }
        public double H3 { get; }

        public Snow(JToken? snowData)
        {
            if (snowData is null)
                throw new ArgumentNullException(nameof(snowData));

            H1 = double.TryParse(snowData.SelectToken("1h")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var h1Result) ? h1Result : 0.0;
            H3 = double.TryParse(snowData.SelectToken("3h")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var h3Result) ? h3Result : 0.0;
        }
    }
}
