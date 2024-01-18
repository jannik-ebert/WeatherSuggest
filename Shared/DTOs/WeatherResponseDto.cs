namespace WeatherSuggest.Shared.DTOs
{
    public record WeatherResponseDto(
        CoordDto Coord,
        List<WeatherDto> Weather,
        string Base,
        MainDto Main,
        int Visibility,
        WindDto Wind,
        CloudsDto Clouds,
        RainDto Rain,
        SnowDto Snow,
        DateTime Dt,
        SysDto Sys,
        string Timezone,
        int ID,
        string Name
        );

    public record CoordDto(double Lon, double Lat);

    public record WeatherDto(int ID, string Main, string Description);

    public record MainDto(double Temp, double FeelsLike, int Pressure, int Humidity, double TempMin, double TempMax, int GrndLevel);

    public record WindDto(double Speed, int Deg, double Gust);

    public record CloudsDto(int All);

    public record RainDto(double H1, double H3);

    public record SnowDto(double H1, double H3);

    public record SysDto(string Country, DateTime Sunrise, DateTime Sunset);
}
