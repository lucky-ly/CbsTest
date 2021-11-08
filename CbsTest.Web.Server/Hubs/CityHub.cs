using CbsTest.Web.Shared.City;
using Microsoft.AspNetCore.SignalR;

namespace CbsTest.Web.Server.Hubs
{
    public class CityHub : Hub<ICityClient>
    {
    }
}
