namespace CbsTest.Web.Shared.City
{
    public interface ICityClient
    {
        Task Create(CityResponse city);
        Task Update(CityResponse city);
        Task Remove(Guid id);
    }
}
