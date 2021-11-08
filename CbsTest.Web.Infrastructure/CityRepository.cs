using CbsTest.Domain;
using CbsTest.Web.Infrastructure.Database;
using CbsTest.Web.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityEntity = CbsTest.Web.Infrastructure.Database.Entities.City;

namespace CbsTest.Web.Infrastructure
{
    public class CityRepository : ICityRepository
    {
        private readonly CityManagementContext _context;

        public CityRepository(CityManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _context.Cities.AsNoTracking().Select(x => new City(x.Id, x.Name, x.Population, x.FoundationDate)).ToArrayAsync();
        }

        public Task<City?> GetByIdAsync(Guid id)
        {
            return _context.Cities.Where(x => x.Id == id).Select(x => new City(x.Id, x.Name, x.Population, x.FoundationDate)).FirstOrDefaultAsync();
        }

        public Task AddAsync(City city)
        {
            _context.Cities.Add(new CityEntity(city.Id, city.Name, city.Population, city.FoundationDate));
            return _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            _context.Cities.Remove(new CityEntity(id, "", 0, default));
            return _context.SaveChangesAsync();
        }

        public Task UpdateAsync(City city)
        {
            _context.Cities.Update(new CityEntity(city.Id, city.Name, city.Population, city.FoundationDate));
            return _context.SaveChangesAsync();
        }
    }
}