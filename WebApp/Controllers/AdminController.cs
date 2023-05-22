using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.Services.Products;
using WebApp.ViewModels.Products;

namespace WebApp.Controllers;

[Authorize (Roles = "admin")]
public class AdminController : Controller
{
    private readonly ProductService _productService;
    private readonly IdentityContext _context;
    private readonly TagService _tagService;

    public AdminController(ProductService productService, IdentityContext context, TagService tagService)
    {
        _productService = productService;
        _context = context;
        _tagService = tagService;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Admin";

        return View();
    }

    public IActionResult Users()
    {
        ViewData["Title"] = "User information";


        return View();
    }


    public IActionResult Products()
    {
        ViewData["Title"] = "Admin Products";

        return View();
    }


    public async Task<IActionResult> AddProduct()
    {
        ViewBag.Tags = await _tagService.GetTagsAsync();
        ViewData["Title"] = "Add product";

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(NewProductViewModel newProductViewModel, string[] tags)
    {
        if (ModelState.IsValid)
        {
            var product = await _productService.CreateAsync(newProductViewModel);
            if (product != null)
            {
                await _productService.AddProductTagsAsync(newProductViewModel, tags);

                if (newProductViewModel.Image != null)
                {
                    await _productService.UploadImageAsync(product, newProductViewModel.Image);

                }

                return RedirectToAction("Index", "Products");
            }


            ModelState.AddModelError("", "Something went wrong");
        }

        ViewBag.Tags = await _tagService.GetTagsAsync(tags);
        return View();
    }

    public IActionResult AddTags()
    {
        ViewData["Title"] = "Add Tags";

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddTags(AddTagsViewModel addTagsViewModel)
    {
        if (ModelState.IsValid)
        {
            await _productService.CreateTagsAsync(addTagsViewModel);

        }

        return View();
    }

    public async Task<IActionResult> Tag()
    {
        ViewData["Title"] = "Product";

        var product = await _tagService.GetTagsAsync();

        return View(product);
    }

}