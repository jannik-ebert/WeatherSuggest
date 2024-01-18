namespace WeatherSuggest.Server.Configuration
{
    public class ApiSettings
    {
        public string? ApiKey { get; set; }

        public ApiSettings(string? apiKey)
        {
            ApiKey = apiKey;
        }
    }
}