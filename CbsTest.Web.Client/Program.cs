using CbsTest.Web.Client;
using CbsTest.Web.Shared.City;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.SignalR.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<CityHttpClient>();

builder.Services.AddSingleton<HubConnection>(x =>
{
    var navigationManager = x.GetRequiredService<NavigationManager>();
    return new HubConnectionBuilder()
          .WithUrl(navigationManager.ToAbsoluteUri("live/city"))
          .WithAutomaticReconnect()
          .Build();
});

await builder.Build().RunAsync();
