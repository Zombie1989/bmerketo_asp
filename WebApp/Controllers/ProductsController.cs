using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WebApp.Contexts;
using WebApp.Services.Products;
using WebApp.ViewModels.Products;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
    private readonly ProductService _productService;
    private readonly DataContext _context;

    public ProductsController(ProductService productService, DataContext context)
    {
        _productService = productService;
        _context = context;
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

    public async Task<IActionResult> Product(int Id)
    {
        ViewData["Title"] = "Product";

        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    public IActionResult AllProducts()
    {
        ViewData["Title"] = "Products";

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
