using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Entities;

public interface IMovieRepository : IRepository<Movie>
{
    Task<IEnumerable<Movie>> GetTop20MoviesAsync();
    Task<Movie?> GetByIdAsync(int id);
    Task<Movie?> GetMovieById(int id);
    Task<bool> DeleteMovieByIdAsync(int id);
    Task<IEnumerable<Movie>> GetHighestGrossingMovies();
    Task<IEnumerable<Movie>> GetAllMoviesAsync();
    Task<IEnumerable<Movie>> GetMoviesByGenreAsync(string genre);
}
