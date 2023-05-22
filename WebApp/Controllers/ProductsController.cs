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

    public async Task<IActionResult> Product(string Id)
    {
        ViewData["Title"] = "Product";

        var product = await _context.Products.FirstOrDefaultAsync(x => x.ArticleNumber == Id);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    public IActionResult AllProducts(string tag)
    {
        ViewData["Title"] = "Products";


        return View();
    }


}
