using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeatherSuggest.Server.Repositories;
using WeatherSuggest.Shared.DTOs;

namespace WeatherSuggest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly IMapper _mapper;

        public WeatherController(IWeatherRepository weatherRepository, IMapper mapper)
        {
            _weatherRepository = weatherRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<WeatherResponseDto> GetWeatherData(double lat, double lon)
        {
            var weatherData = await _weatherRepository.GetWeatherDataAsync(lat, lon);
            var weatherDataDtos = _mapper.Map<WeatherResponseDto>(weatherData);

            return weatherDataDtos;
        }
    }
}
