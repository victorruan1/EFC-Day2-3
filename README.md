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

Open http://localhost:5000 (or as shown in console).

## Notes
- Repositories are in-memory (no DB). `MovieService` returns seeded `MovieCardModel` items for the home page.
- `_MovieCard.cshtml` partial is used by `Home/Index` and `Movies/Index` to demonstrate reuse.
- Add your own poster images to `MovieShop.MVC/wwwroot/images/` or adjust the URLs in `MovieRepository`.
