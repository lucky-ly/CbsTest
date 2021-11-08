using CbsTest.Web.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;

namespace CbsTest.Web.Infrastructure.Database
{
    internal class SampleData
    {
        public static IEnumerable<City> GetCities() => new[] {
                new City(Guid.NewGuid(), "City 1", 50, DateOnly.Parse("2021-01-13")),
                new City(Guid.NewGuid(), "City 2", 42, DateOnly.Parse("2007-06-19")),
                new City(Guid.NewGuid(), "City 3", 66, DateOnly.Parse("2020-05-15")),
                new City(Guid.NewGuid(), "City 4", 83, DateOnly.Parse("2018-09-18")),
                new City(Guid.NewGuid(), "City 5", 15, DateOnly.Parse("2016-03-15")),
                new City(Guid.NewGuid(), "City 6", 34, DateOnly.Parse("2010-02-17")),
                new City(Guid.NewGuid(), "City 17", 2, DateOnly.Parse("2003-01-24")),
                new City(Guid.NewGuid(), "WhatTheHellBurg", 666, DateOnly.Parse("1950-08-17")),
        };
    }
}
