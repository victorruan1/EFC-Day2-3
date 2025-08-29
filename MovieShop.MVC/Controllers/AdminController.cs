using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;

namespace MovieShop.MVC.Controllers;

public class AdminController : Controller
{
    private readonly IAdminService _adminService;
    public AdminController(IAdminService adminService) => _adminService = adminService;

    public async Task<IActionResult> TopMovies()
    {
        var report = await _adminService.GetTopPurchasedMoviesAsync();
        return View(report);
    }
}
