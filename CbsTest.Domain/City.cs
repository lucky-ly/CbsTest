using System;

namespace CbsTest.Domain
{
    public class City
    {
        public City(Guid id, string name, int population, DateOnly foundationDate)
        {
            this.Id = id;
            this.Name = name;
            this.Population = population;
            this.FoundationDate = foundationDate;
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public int Population { get; set; }
        public DateOnly FoundationDate { get; set; }

        public static City Create(string name, int population, DateOnly foundationDate) => new City(Guid.NewGuid(), name, population, foundationDate);
    }
}
