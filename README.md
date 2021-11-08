# Test task
App should manage simple catalog of cities.

Cities must consist of
- Identifier
- Name
- Population count
- Foundation date

Additional requirements were:
- Blazor WebAssembly for Frontend
- ASP.NET Core for Backend
- In-memory database
- Clients should synchronize data without page refreshes, preferably via SignalR hub

### How to run

Make sure you have latest .NET 6 runtime installed

`dotnet build` to build

`dotnet run --project CbsTest.Web.Server` in root folder to run
