using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebApp.Services.Products;
using WebApp.ViewModels.Products;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        ViewData["Title"] = "Products";

        return View();
    }

    public IActionResult Search()
    {
        ViewData["Title"] = "Search for product";

        return View();
    }

    public IActionResult Product()
    {
        ViewData["Title"] = "Product";

        return View();
    }

    public IActionResult AddProduct()
    {
        ViewData["Title"] = "Add product";

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(NewProductViewModel newProductViewModel)
    {
        if (ModelState.IsValid)
        {
            if (await _productService.CreateAsync(newProductViewModel))
                return RedirectToAction("Index", "Products");

            ModelState.AddModelError("", "Something went wrong");
        }

        return View();
    }
}
