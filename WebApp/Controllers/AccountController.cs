using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services.Account;
using WebApp.ViewModels.Account;

namespace WebApp.Controllers;

public class AccountController : Controller
{
    private readonly AuthService _authentication;

    public AccountController(AuthService authentication)
    {
        _authentication = authentication;
    }
    [Authorize]
    public IActionResult Index()
    {
        ViewData["Title"] = "Login";

        return View();
    }

    public IActionResult Login()
    {
        ViewData["Title"] = "Login";

        return View();
    }

    public IActionResult NewAccount()
    {
        ViewData["Title"] = "New Account";

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> NewAccount(SignUpViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (await _authentication.SignUpAsync(model))
                return RedirectToAction("Login");

            ModelState.AddModelError("", "Something went wrong, please try again");
        }

        return View(model);
    }
}
