using MovieShop.ApplicationCore.Models;

namespace MovieShop.ApplicationCore.Contracts.Services;

public interface IMovieService
{
    Task<IEnumerable<MovieCardModel>> GetTop20MoviesAsync();
    Task<MovieDetailsModel?> GetMovieDetailsByIdAsync(int id);
    Task<bool> DeleteMovieByIdAsync(int id);
    Task<IEnumerable<MovieCardModel>> GetHighestGrossingMoviesAsync();
    Task<IEnumerable<MovieCardModel>> GetAllMoviesAsync();
    Task<IEnumerable<MovieCardModel>> GetMoviesByGenreAsync(string genre);
}
