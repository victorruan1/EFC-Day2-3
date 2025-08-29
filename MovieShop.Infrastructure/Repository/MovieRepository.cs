using Microsoft.EntityFrameworkCore;
using MovieShop.ApplicationCore.Entities;
using MovieShop.Infrastructure.Data;
using MovieShop.Infrastructure.Repository;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(MovieShopDbContext context)
        : base(context) { }

    public async Task<IEnumerable<Movie>> GetTop20MoviesAsync()
    {
        return await _context.Movie.OrderByDescending(m => m.Revenue).Take(20).ToListAsync();
    }

    public async Task<IEnumerable<Movie>> GetHighestGrossingMovies()
    {
        return await _context.Movie.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
    }

    public async Task<Movie?> GetByIdAsync(int id)
    {
        return await _context.Movie.FindAsync(id);
    }

    public async Task<Movie?> GetMovieById(int id)
    {
        return await _context
            .Movie.Include(m => m.Trailers)
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .Include(m => m.MovieCasts)
            .ThenInclude(mc => mc.Cast)
            .Include(m => m.Reviews)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public Task<bool> DeleteMovieByIdAsync(int id)
    {
        var movie = DeleteById(id);
        return Task.FromResult(movie != null);
    }

    public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
    {
        return await _context.Movie.OrderBy(m => m.Title).ToListAsync();
    }

    public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genre)
    {
        return await _context
            .Movie.Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .Where(m => m.MovieGenres.Any(mg => mg.Genre != null && mg.Genre.Name == genre))
            .OrderBy(m => m.Title)
            .ToListAsync();
    }
}
