using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;

namespace MovieShop.MVC.Controllers;

public class HomeController : Controller
{
    private readonly IMovieService _movieService;

    public HomeController(IMovieService movieService) => _movieService = movieService;

    public async Task<IActionResult> Index()
    {
        var cards = await _movieService.GetTop20MoviesAsync();
        return View(cards);
    }
}
