namespace MovieShop.ApplicationCore.Contracts.Repository;

public interface ICastRepository
{
    Task<IEnumerable<string>> GetCastNamesByMovieIdAsync(int movieId);
    Task<MovieShop.ApplicationCore.Entities.Cast?> GetCastByIdWithMoviesAsync(int castId);
}
