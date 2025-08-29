using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Models;

namespace MovieShop.Infrastructure.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepo;

    public MovieService(IMovieRepository movieRepo)
    {
        _movieRepo = movieRepo;
    }

    public async Task<IEnumerable<MovieCardModel>> GetTop20MoviesAsync()
    {
        var movies = await _movieRepo.GetTop20MoviesAsync();
        return movies.Select(m => new MovieCardModel
        {
            Id = m.Id,
            Title = m.Title,
            PosterUrl = m.PosterUrl,
        });
    }

    public async Task<MovieDetailsModel?> GetMovieDetailsByIdAsync(int id)
    {
        var m = await _movieRepo.GetMovieById(id);
        if (m == null)
            return null;

        return new MovieDetailsModel
        {
            Id = m.Id,
            Title = m.Title ?? string.Empty,
            PosterUrl = m.PosterUrl,
            Overview = m.Overview,
            TagLine = m.TagLine,
            Budget = m.Budget,
            Revenue = m.Revenue,
            Trailers = m.Trailers?.Select(t => new TrailerModel
            {
                Name = t.Name ?? string.Empty,
                Url = t.TrailerUrl ?? string.Empty,
            }),
            Genres = m.MovieGenres?.Select(mg => mg.Genre?.Name ?? string.Empty),
            Cast = m.MovieCasts?.Select(mc => new CastModel
            {
                Id = mc.CastId,
                Name = mc.Cast?.Name ?? string.Empty,
                Character = mc.Character ?? string.Empty,
                ProfilePath = mc.Cast?.ProfilePath,
            }),
            Reviews = m.Reviews?.Select(r => new ReviewModel
            {
                Rating = r.Rating,
                ReviewText = r.ReviewText,
                CreatedDate = r.CreatedDate,
            }),
            Rating = m.Reviews != null && m.Reviews.Any() ? m.Reviews.Average(r => r.Rating) : null,
            Price = m.Price,
        };
    }

    public Task<bool> DeleteMovieByIdAsync(int id)
    {
        return _movieRepo.DeleteMovieByIdAsync(id);
    }

    public async Task<IEnumerable<MovieCardModel>> GetHighestGrossingMoviesAsync()
    {
        var movies = await _movieRepo.GetHighestGrossingMovies();
        return movies.Select(m => new MovieCardModel
        {
            Id = m.Id,
            Title = m.Title,
            PosterUrl = m.PosterUrl,
        });
    }

    public async Task<IEnumerable<MovieCardModel>> GetAllMoviesAsync()
    {
        var movies = await _movieRepo.GetAllMoviesAsync();
        return movies.Select(m => new MovieCardModel
        {
            Id = m.Id,
            Title = m.Title,
            PosterUrl = m.PosterUrl,
        });
    }

    public async Task<IEnumerable<MovieCardModel>> GetMoviesByGenreAsync(string genre)
    {
        var movies = await _movieRepo.GetMoviesByGenreAsync(genre);
        return movies.Select(m => new MovieCardModel
        {
            Id = m.Id,
            Title = m.Title,
            PosterUrl = m.PosterUrl,
        });
    }
}
