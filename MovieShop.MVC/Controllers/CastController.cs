using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;

namespace MovieShop.MVC.Controllers;

public class CastController : Controller
{
    private readonly ICastService _castService;

    public CastController(ICastService castService) => _castService = castService;

    public async Task<IActionResult> ByMovie(int id)
    {
        var cast = await _castService.GetCastForMovieAsync(id);
        return View(cast);
    }

    public async Task<IActionResult> Details(int id)
    {
        var details = await _castService.GetCastDetailsAsync(id);
        if (details == null)
            return NotFound();
        return View(details);
    }
}
