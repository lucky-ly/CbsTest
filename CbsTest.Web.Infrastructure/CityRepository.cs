using CbsTest.Domain;
using CbsTest.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CbsTest.Web.Infrastructure
{
    public class CityRepository : ICityRepository
    {
        public Task AddAsync(City city)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return new[] { new City(Guid.NewGuid(), "WhatTheHellBurg", 666, DateOnly.Parse("1950-08-17")) };
        }

        public Task<City> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(City newCity)
        {
            throw new NotImplementedException();
        }
    }
}