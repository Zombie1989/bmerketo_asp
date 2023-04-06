using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class AccountController : Controller
{
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
}
