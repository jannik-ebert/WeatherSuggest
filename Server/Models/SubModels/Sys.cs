using Newtonsoft.Json.Linq;
using System.Globalization;

namespace WeatherSuggest.Server.Models.SubModels
{
    public class Sys
    {
        public string? Country { get; }
        public DateTime Sunrise { get; }
        public DateTime Sunset { get; }

        public Sys(JToken? sysData)
        {
            if (sysData is null)
                throw new ArgumentNullException(nameof(sysData));

            Country = sysData.SelectToken("country")?.ToString() ?? string.Empty;
            Sunrise = ConvertUnixToDateTime(int.TryParse(sysData.SelectToken("sunrise")?.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture, out var sunriseResult) ? sunriseResult : 0);
            Sunset = ConvertUnixToDateTime(int.TryParse(sysData.SelectToken("sunset")?.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture, out var sunsetResult) ? sunsetResult : 0);
        }

        private static DateTime ConvertUnixToDateTime(int unixTimestamp)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp);
            return dateTimeOffset.DateTime;
        }
    }
}
