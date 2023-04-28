using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Authorize]
public class MyAccountController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = User.FindFirst("Displayname")?.Value;

        return View();
    }
}
