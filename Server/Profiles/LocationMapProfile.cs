using AutoMapper;
using WeatherSuggest.Server.Models;
using WeatherSuggest.Shared.DTOs;

namespace WeatherSuggest.Server.Profiles
{
    public class LocationMapProfile : Profile
    {
        public LocationMapProfile()
        {
            this.CreateMap<GeoResponse, GeoResponseDto>();
        }
    }
}
