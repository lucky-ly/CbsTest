using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CbsTest.Domain;

namespace CbsTest.Web.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllAsync();
        Task<City> GetByIdAsync(Guid id);
        Task AddAsync(City city);
        Task UpdateAsync(City newCity);
    }
}