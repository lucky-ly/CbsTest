using Microsoft.AspNetCore.Mvc;
using CbsTest.Web.Interfaces;
using CbsTest.Web.Shared.City;
using City = CbsTest.Domain.City;
using Microsoft.AspNetCore.SignalR;
using CbsTest.Web.Server.Hubs;

namespace CbsTest.Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly ILogger<CityController> _logger;
        private readonly ICityRepository _cityRepository;
        private readonly IHubContext<CityHub, ICityClient> _hubContext;

        public CityController(ILogger<CityController> logger, ICityRepository cityRepository, IHubContext<CityHub, ICityClient> hubContext)
        {
            _logger = logger;
            _cityRepository = cityRepository;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IEnumerable<CityResponse>> Get()
        {
            var allCities = await _cityRepository.GetAllAsync();
            return allCities.Select(x => new CityResponse(x.Id, x.Name, x.Population, x.FoundationDate.ToDateTime(TimeOnly.MinValue)));
        }

        [HttpPost]
        public async Task<CityResponse> Post(CreateCityRequest request)
        {
            var newCity = City.Create(request.Name, request.Population, DateOnly.FromDateTime(request.FoundationDate));
            await _cityRepository.AddAsync(newCity);
            var response = new CityResponse(newCity.Id, newCity.Name, newCity.Population, newCity.FoundationDate.ToDateTime(TimeOnly.MinValue));
            _hubContext.Clients.All.Create(response);
            return response;
        }

        [HttpPut("{id}")]
        public async Task<CityResponse> Put(UpdateCityRequest request)
        {
            var newCity = new City(request.Id, request.Name, request.Population, DateOnly.FromDateTime(request.FoundationDate));
            await _cityRepository.UpdateAsync(newCity);
            var response = new CityResponse(newCity.Id, newCity.Name, newCity.Population, newCity.FoundationDate.ToDateTime(TimeOnly.MinValue));
            _hubContext.Clients.All.Update(response);
            return response;
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _cityRepository.DeleteAsync(id);
            _hubContext.Clients.All.Remove(id);
        }
    }
}