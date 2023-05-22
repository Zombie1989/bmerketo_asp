using Microsoft.AspNetCore.Mvc;
using WebApp.Services.Contacts;
using WebApp.ViewModels.Contacts;

namespace WebApp.Controllers;

public class ContactsController : Controller
{
    private readonly ContactService _contactService;

    public ContactsController(ContactService contactService)
    {
        _contactService = contactService;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Contacts";

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactFormViewModel contactFormViewModel)
    {
        if (ModelState.IsValid) 
        {
            if (await _contactService.CreateAsync(contactFormViewModel))
                return RedirectToAction("Index");

            ModelState.AddModelError("", "Something went wrong please try again");
        }

        return View();
    }
}
