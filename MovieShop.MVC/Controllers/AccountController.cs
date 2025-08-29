using Microsoft.AspNetCore.Mvc;
using MovieShop.ApplicationCore.Contracts.Services;

namespace MovieShop.MVC.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    public AccountController(IAccountService accountService) => _accountService = accountService;

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        if (await _accountService.LoginAsync(email, password)) return RedirectToAction("Index", "Home");
        ModelState.AddModelError("", "Invalid credentials");
        return View();
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(string firstName, string lastName, string email, string password)
    {
        if (await _accountService.RegisterAsync(firstName, lastName, email, password))
            return RedirectToAction("Login");
        ModelState.AddModelError("", "Unable to register");
        return View();
    }
}
