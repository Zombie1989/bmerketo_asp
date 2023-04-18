using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.Models.Products;
using WebApp.ViewModels.Products;

namespace WebApp.Services.Products;

public class ProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(NewProductViewModel newProductViewModel)
    {
        try
        {
            ProductEntity productEntity = newProductViewModel;

            _context.Add(productEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<IEnumerable<ProductModel>> GetAllAsync()
    {
        var products = new List<ProductModel>();
        var items = await _context.Products.ToListAsync();
        foreach (var item in items) 
            {
            ProductModel productModel = item;
            products.Add(productModel);
            }

        return products;
    }
}
