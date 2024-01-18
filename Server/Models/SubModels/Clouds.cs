using Newtonsoft.Json.Linq;
using System.Globalization;

namespace WeatherSuggest.Server.Models.SubModels
{
    public class Clouds
    {
        public int All { get; }

        public Clouds(JToken? cloudsData)
        {
            if (cloudsData is null)
                throw new ArgumentNullException(nameof(cloudsData));

            All = int.TryParse(cloudsData.SelectToken("all")?.ToString(), NumberStyles.Integer, CultureInfo.CurrentCulture, out var allResult) ? allResult : 0;
        }
    }
}
