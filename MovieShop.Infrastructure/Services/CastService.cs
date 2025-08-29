using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Entities;
using MovieShop.ApplicationCore.Models;

namespace MovieShop.Infrastructure.Services;

public class CastService : ICastService
{
    private readonly ICastRepository _castRepo;

    public CastService(ICastRepository castRepo) => _castRepo = castRepo;

    public Task<IEnumerable<string>> GetCastForMovieAsync(int movieId) =>
        _castRepo.GetCastNamesByMovieIdAsync(movieId);

    public async Task<CastDetailsModel?> GetCastDetailsAsync(int castId)
    {
        var cast = await _castRepo.GetCastByIdWithMoviesAsync(castId);
        if (cast == null)
            return null;

        return new CastDetailsModel
        {
            Id = cast.Id,
            Name = cast.Name,
            ProfilePath = cast.ProfilePath,
            Movies =
                cast.MovieCasts?.Select(mc => (mc.MovieId, mc.Movie?.Title ?? string.Empty))
                ?? Enumerable.Empty<(int, string)>(),
        };
    }
}
