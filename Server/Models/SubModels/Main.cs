using Newtonsoft.Json.Linq;
using System.Globalization;

namespace WeatherSuggest.Server.Models.SubModels
{
    public class Main
    {
        public double Temp { get; }
        public double FeelsLike { get; }
        public int Pressure { get; }
        public int Humidity { get; }
        public double TempMin { get; }
        public double TempMax { get; }
        public int GrndLevel { get; }

        public Main(JToken? mainData)
        {
            if (mainData is null)
                throw new ArgumentNullException(nameof(mainData));

            Temp = double.TryParse(mainData.SelectToken("temp")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var tempResult) ? tempResult : 0.0;
            FeelsLike = double.TryParse(mainData.SelectToken("feels_like")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var feelsLikeResult) ? feelsLikeResult : 0.0;
            Pressure = int.TryParse(mainData.SelectToken("pressure")?.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture, out var pressureResult) ? pressureResult : 0;
            Humidity = int.TryParse(mainData.SelectToken("humidity")?.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture, out var humidityResult) ? humidityResult : 0;
            TempMin = double.TryParse(mainData.SelectToken("temp_min")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var tempMinResult) ? tempMinResult : 0.0;
            TempMax = double.TryParse(mainData.SelectToken("temp_max")?.ToString(), NumberStyles.Float, CultureInfo.CurrentCulture, out var tempMaxResult) ? tempMaxResult : 0.0;
            GrndLevel = int.TryParse(mainData.SelectToken("grnd_level")?.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture, out var grndLevelResult) ? grndLevelResult : 0;
        }
    }
}
