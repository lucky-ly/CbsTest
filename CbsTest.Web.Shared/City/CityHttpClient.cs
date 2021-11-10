using System.Net.Http.Json;

namespace CbsTest.Web.Shared.City
{
    public class CityHttpClient
    {
        private readonly HttpClient _httpClient;

        public CityHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CityResponse>> GetAllAsync()
        {
            return (await _httpClient.GetFromJsonAsync<CityResponse[]>("api/city")) ?? Array.Empty<CityResponse>();
        }

        public async Task<CityResponse> CreateAsync(CreateCityRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/city", request);
            var returnValue = await response.Content.ReadFromJsonAsync<CityResponse>();
            return returnValue;
        }

        public Task UpdateAsync(UpdateCityRequest request)
        {
            return _httpClient.PutAsJsonAsync($"api/city/{request.Id}", request);
        }

        public Task DeleteAsync(Guid id)
        {
            return _httpClient.DeleteAsync($"api/city/{id}");
        }

    }
}
