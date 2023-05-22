using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Services.Admin;

namespace WebApp.Controllers;

[Authorize]
public class MyAccountController : Controller
{
    private readonly UserService _userService;

    public MyAccountController(UserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {        
        ViewData["Title"] = User.FindFirst("Displayname")?.Value;

        return View();
    }
}
