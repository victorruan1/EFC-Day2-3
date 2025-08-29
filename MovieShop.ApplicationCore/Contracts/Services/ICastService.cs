namespace MovieShop.ApplicationCore.Contracts.Services;

public interface ICastService
{
    Task<IEnumerable<string>> GetCastForMovieAsync(int movieId);
    Task<MovieShop.ApplicationCore.Models.CastDetailsModel?> GetCastDetailsAsync(int castId);
}
