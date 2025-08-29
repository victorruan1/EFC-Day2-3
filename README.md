# MovieShop (Clean Architecture Demo)

Three-layer ASP.NET Core MVC solution:
- **MovieShop.ApplicationCore** — interfaces, models, entities
- **MovieShop.Infrastructure** — repository + service implementations, DI module
- **MovieShop.MVC** — MVC app (controllers + views)

## Build & Run
```bash
dotnet restore
dotnet build
dotnet run --project MovieShop.MVC
```
