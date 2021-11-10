using CbsTest.Web.Shared.City;
using Microsoft.AspNetCore.SignalR.Client;

namespace CbsTest.Web.Client.City
{
    public class CityHubClient
    {
        private readonly HubConnection _cityHub;

        public CityHubClient(HubConnection cityHub)
        {
            _cityHub = cityHub;
        }

        public void Create(CityResponse city)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(CityResponse city)
        {
            throw new NotImplementedException();
        }
    }
}
