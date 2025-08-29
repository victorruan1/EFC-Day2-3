using Microsoft.Extensions.DependencyInjection;
using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.Infrastructure.Repository;
using MovieShop.Infrastructure.Services;

namespace MovieShop.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddMovieShopInfrastructure(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICastRepository, CastRepository>();
        services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();

        // Services
        services.AddScoped<IMovieService, MovieService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IGenreService, GenreService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<ICastService, CastService>();

        return services;
    }
}
