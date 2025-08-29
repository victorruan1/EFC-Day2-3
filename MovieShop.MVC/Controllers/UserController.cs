using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;
using MovieShop.ApplicationCore.Entities;
using MovieShop.Infrastructure.Data;

namespace MovieShop.MVC.Controllers;

public class UserController : Controller
{
    private readonly IUserService _userService;
    private readonly MovieShopDbContext _context;

    public UserController(IUserService userService, MovieShopDbContext context)
    {
        _userService = userService;
        _context = context;
    }

    public IActionResult Purchases() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Purchase(int movieId)
    {
        // Demo flow: ensure a demo user exists and use that user's id.
        // Replace with authenticated user id when auth is available.
        const string demoEmail = "demo@local";
        var user = _context.Users.FirstOrDefault(u => u.Email == demoEmail);
        if (user == null)
        {
            user = new User
            {
                Email = demoEmail,
                FirstName = "Demo",
                LastName = "User",
                HashedPassword = "demo",
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        var userId = user.Id;

        // If the user already purchased this movie, don't insert again.
        var already = _context.Purchases.Any(p => p.UserId == userId && p.MovieId == movieId);
        if (already)
        {
            return RedirectToAction("Details", "Movies", new { id = movieId, purchased = true });
        }

        var movie = _context.Movie.Find(movieId);
        var purchase = new Purchase
        {
            MovieId = movieId,
            UserId = userId,
            PurchaseDateTime = DateTime.UtcNow,
            PurchaseNumber = Guid.NewGuid(),
            TotalPrice = movie?.Price ?? 0m,
        };

        _context.Purchases.Add(purchase);
        try
        {
            _context.SaveChanges();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }

        return RedirectToAction("Details", "Movies", new { id = movieId, purchased = true });
    }
}
