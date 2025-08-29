using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Models;

namespace MovieShop.MVC.Controllers;

public class GenresController : Controller
{
    private readonly IMovieService _movieService;
    private readonly IGenreService _genreService;

    public GenresController(IMovieService movieService, IGenreService genreService)
    {
        _movieService = movieService;
        _genreService = genreService;
    }

    public async Task<IActionResult> Index(string name)
    {
        ViewBag.Genres = await _genreService.GetAllAsync();
        if (string.IsNullOrWhiteSpace(name))
        {
            var all = await _movieService.GetAllMoviesAsync();
            return View(all);
        }

        var movies = await _movieService.GetMoviesByGenreAsync(name);
        ViewBag.SelectedGenre = name;
        return View(movies);
    }
}
