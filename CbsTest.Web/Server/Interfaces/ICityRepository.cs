using CbsTest.Web.Server.Domain;

namespace CbsTest.Web.Server.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllAsync();
        Task<City> GetByIdAsync(Guid id);
        Task AddAsync(City city);
        Task UpdateAsync(City newCity);
    }
}