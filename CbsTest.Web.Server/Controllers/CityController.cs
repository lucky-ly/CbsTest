using Microsoft.AspNetCore.Mvc;
using CbsTest.Web.Interfaces;
using CbsTest.Web.Shared.City;
using City = CbsTest.Domain.City;

namespace CbsTest.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly ICityRepository _cityRepository;

        public CityController(ILogger<CityController> logger, ICityRepository cityRepository)
        {
            _logger = logger;
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<CityResponse>> Get()
        {
            var allCities = await _cityRepository.GetAllAsync();
            return allCities.Select(x => new CityResponse(x.Id, x.Name, x.Population, x.FoundationDate.ToDateTime(TimeOnly.MinValue)));
        }

        [HttpGet("{id}")]
        public async Task<CityResponse> Get(Guid id)
        {
            var city = await _cityRepository.GetByIdAsync(id);
            return new CityResponse(city.Id, city.Name, city.Population, city.FoundationDate.ToDateTime(TimeOnly.MinValue));
        }

        [HttpPost]
        public async Task<CityResponse> Post(CreateCityRequest request)
        {
            var newCity = City.Create(request.Name, request.Population, DateOnly.FromDateTime(request.FoundationDate));
            await _cityRepository.AddAsync(newCity);
            // send NewCityCreatedEvent
            return new CityResponse(newCity.Id, newCity.Name, newCity.Population, newCity.FoundationDate.ToDateTime(TimeOnly.MinValue));
        }

        [HttpPut("{id}")]
        public async Task<CityResponse> Put(UpdateCityRequest request)
        {
            var newCity = new City(request.Id, request.Name, request.Population, DateOnly.FromDateTime(request.FoundationDate));
            await _cityRepository.UpdateAsync(newCity);
            // send CityUpdatedEvent
            return new CityResponse(newCity.Id, newCity.Name, newCity.Population, newCity.FoundationDate.ToDateTime(TimeOnly.MinValue));
        }
    }
}