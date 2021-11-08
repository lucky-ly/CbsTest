namespace CbsTest.Web.Shared.City
{
    public class City
    {
        public City(string name, int population, DateTime foundationDate)
        {
            Id = Guid.Empty;
            Name = name;
            Population = population;
            FoundationDate = foundationDate;
        }

        public City(CityResponse response)
        {
            Id = response.Id;
            Name = response.Name;
            Population = response.Population;
            FoundationDate = response.FoundationDate;
        }

        public Guid Id { get; }
        public string Name { get; set; }
        public int Population { get; set; }
        public DateTime FoundationDate { get; set; }

        public UpdateCityRequest ToUpdateRequest() => new(Id, Name, Population, FoundationDate);
        public CreateCityRequest ToCreateRequest() => new(Name, Population, FoundationDate);
    }
}
