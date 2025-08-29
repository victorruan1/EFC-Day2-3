using Microsoft.EntityFrameworkCore;
using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Entities;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repository;

public class CastRepository : ICastRepository
{
    private readonly MovieShopDbContext _context;

    public CastRepository(MovieShopDbContext context) => _context = context;

    public Task<IEnumerable<string>> GetCastNamesByMovieIdAsync(int movieId) =>
        Task.FromResult<IEnumerable<string>>(new[] { "Actor A", "Actor B", "Actor C" });

    public async Task<Cast?> GetCastByIdWithMoviesAsync(int castId)
    {
        return await _context
            .Casts.Include(c => c.MovieCasts)
            .ThenInclude(mc => mc.Movie)
            .FirstOrDefaultAsync(c => c.Id == castId);
    }
}
