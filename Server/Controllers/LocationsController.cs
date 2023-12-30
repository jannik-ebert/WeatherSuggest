using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WeatherSuggest.Server.Repositories;
using WeatherSuggest.Shared.DTOs;

namespace WeatherSuggest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsRepository _locationsRepository;
        private readonly IMapper _mapper;

        public LocationsController(ILocationsRepository locationsRepository, IMapper mapper)
        {
            _locationsRepository = locationsRepository;
            _mapper = mapper;
        }

        [HttpGet("{city}")]
        public async Task<IEnumerable<GeoResponseDto>> GetLocations(string city)
        {
            var locations = await _locationsRepository.GetLocationsAsync(city);
            var locationDtos = _mapper.Map<List<GeoResponseDto>>(locations);

            return locationDtos;
        }
    }
}
