namespace CbsTest.Web.Shared.City
{
    public record UpdateCityRequest(Guid Id, string Name, int Population, DateTime FoundationDate);
}
