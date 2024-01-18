using Newtonsoft.Json.Linq;
using System.Globalization;
using WeatherSuggest.Server.Models.SubModels;

namespace WeatherSuggest.Server.Models
{
    public class WeatherResponse
    {
        public Coord? Coord { get; }
        public List<Weather?> Weather { get; } = new List<Weather?>();
        public string? Base { get; }
        public Main? Main { get; }
        public int Visibility { get; }
        public Wind? Wind { get; }
        public Clouds? Clouds { get; }
        public Rain? Rain { get; }
        public Snow? Snow { get; }
        public DateTime Dt { get; }
        public Sys? Sys { get; }
        public string? Timezone { get; }
        public int ID { get; }
        public string? Name { get; }

        public WeatherResponse(JObject jsonResponse)
        {
            Coord = new Coord(jsonResponse.SelectToken("coord"));
            JToken? weatherToken = jsonResponse.SelectToken("weather");
            if (weatherToken != null)
            {
                foreach (JToken weather in weatherToken)
                {
                    Weather?.Add(new Weather(weather));
                }
            }
            Base = jsonResponse.SelectToken("base")?.ToString();
            Main = new Main(jsonResponse.SelectToken("main"));
            Visibility = int.TryParse(jsonResponse.SelectToken("visibility")?.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture, out var visResult) ? visResult : 0;
            Wind = new Wind(jsonResponse.SelectToken("wind"));
            Clouds = new Clouds(jsonResponse.SelectToken("clouds"));
            if (jsonResponse.SelectToken("rain") != null)
                Rain = new Rain(jsonResponse.SelectToken("rain"));
            if (jsonResponse.SelectToken("snow") != null)
                Snow = new Snow(jsonResponse.SelectToken("snow"));
            Dt = ConvertUnixToDateTime(int.TryParse(jsonResponse.SelectToken("dt")?.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture, out var dtResult) ? dtResult : 0);
            Sys = new Sys(jsonResponse.SelectToken("sys"));
            Timezone = CalculateTimezone(int.TryParse(jsonResponse.SelectToken("timezone")?.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture, out var tzResult) ? tzResult : 0);
            ID = int.TryParse(jsonResponse.SelectToken("id")?.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture, out var idResult) ? idResult : 0;
            Name = jsonResponse.SelectToken("name")?.ToString();
        }

        private static DateTime ConvertUnixToDateTime(int unixTimestamp)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimestamp);
            return dateTimeOffset.DateTime;
        }

        private static string CalculateTimezone(int shiftInSecondsFromUTC)
        {
            TimeSpan timeShift = TimeSpan.FromSeconds(shiftInSecondsFromUTC);

            string sign = (timeShift >= TimeSpan.Zero) ? "+" : "-";
            string hours = Math.Abs(timeShift.Hours).ToString();
            string minutes = (timeShift.Minutes == 0) ? string.Empty : $":{Math.Abs(timeShift.Minutes)}";

            return $"UTC{sign}{hours}{minutes}";
        }
    }
}
