using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels.Products;

namespace WebApp.Controllers;

public class ProductsController : Controller
{
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
            
        }

        return View();
    }
}
