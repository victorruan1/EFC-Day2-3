using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;

namespace MovieShop.MVC.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;
    private readonly IGenreService _genreService;

    public MoviesController(IMovieService movieService, IGenreService genreService)
    {
        _movieService = movieService;
        _genreService = genreService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Genres = await _genreService.GetAllAsync();
        var cards = await _movieService.GetTop20MoviesAsync();
        return View(cards);
    }

    public async Task<IActionResult> All()
    {
        ViewBag.Genres = await _genreService.GetAllAsync();
        var cards = await _movieService.GetAllMoviesAsync();
        return View("Index", cards);
    }

    public async Task<IActionResult> Details(int id)
    {
        var details = await _movieService.GetMovieDetailsByIdAsync(id);
        if (details == null)
            return NotFound();
        return View(details);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _movieService.DeleteMovieByIdAsync(id);
        if (!success)
            return NotFound();

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddReview(int movieId, int rating, string reviewText)
    {
        // Demo: user id is hard-coded to 1.
        var review = new MovieShop.ApplicationCore.Entities.Review
        {
            MovieId = movieId,
            UserId = 1,
            CreatedDate = DateTime.UtcNow,
            Rating = rating,
            ReviewText = reviewText,
        };

        using var scope = HttpContext.RequestServices.CreateScope();
        var db =
            scope.ServiceProvider.GetRequiredService<MovieShop.Infrastructure.Data.MovieShopDbContext>();
        db.Reviews.Add(review);
        db.SaveChanges();

        return RedirectToAction("Details", new { id = movieId });
    }
}
