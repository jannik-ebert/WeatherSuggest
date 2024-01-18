namespace WeatherSuggest.Shared.DTOs
{
    public record GeoResponseDto(string Name, double Lat, double Lon, string Country, string State);
}
