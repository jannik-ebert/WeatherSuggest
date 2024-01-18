using AutoMapper;
using WeatherSuggest.Server.Models;
using WeatherSuggest.Server.Models.SubModels;
using WeatherSuggest.Shared.DTOs;

namespace WeatherSuggest.Server.Profiles
{
    public class WeatherMapProfile : Profile
    {
        public WeatherMapProfile()
        {
            this.CreateMap<WeatherResponse, WeatherResponseDto>();
            this.CreateMap<Coord, CoordDto>();
            this.CreateMap<Weather, WeatherDto>();
            this.CreateMap<Main, MainDto>();
            this.CreateMap<Wind, WindDto>();
            this.CreateMap<Clouds, CloudsDto>();
            this.CreateMap<Rain, RainDto>();
            this.CreateMap<Snow, SnowDto>();
            this.CreateMap<Sys, SysDto>();
        }
    }
}
