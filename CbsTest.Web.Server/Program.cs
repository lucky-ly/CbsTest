using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using CbsTest.Web.Interfaces;
using CbsTest.Web.Infrastructure;
using CbsTest.Web.Infrastructure.Database;
using CbsTest.Web.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddDbContext<CityManagementContext>(o => o.UseInMemoryDatabase("CbsTestDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapHub<CityHub>("/live/city");
app.MapFallbackToFile("index.html");

app.Run();
