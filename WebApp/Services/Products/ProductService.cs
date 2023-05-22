using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models.Dtos;
using WebApp.Models.Entities;
using WebApp.Models.Products;
using WebApp.Repositories;
using WebApp.ViewModels.Products;

namespace WebApp.Services.Products;

public class ProductService
{
    private readonly DataContext _context;
    private readonly ProductRepository _productRepo;
    private readonly ProductTagRepository _productTagRepo;
    private readonly TagRepo _TagRepo;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductService(DataContext context, ProductRepository productRepo, ProductTagRepository productTagRepo, TagRepo tagRepo, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _productRepo = productRepo;
        _productTagRepo = productTagRepo;
        _TagRepo = tagRepo;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<Product> CreateAsync(ProductEntity entity)
    {
        var _entity = await _productRepo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
        if (_entity == null)
        {
            _entity = await _productRepo.AddAsync(entity);
            if (_entity != null)
                return _entity;
        }
        return null!;
    }

    /*public async Task<bool> CreateAsync(NewProductViewModel newProductViewModel)
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
    }*/

    public async Task<IEnumerable<ProductModel>> GetAllAsync()
    {
        var products = new List<ProductModel>();
        var items = await _context.Products.Include(x => x.ProductTags).ThenInclude(j => j.Tag).ToListAsync();
        foreach (var item in items) 
            {

            ProductModel model = new ProductModel();

            model.Id = item.ArticleNumber;
            model.Name = item.Name;
            model.Price = item.Price;
            model.Description = item.Description;
            model.Category = item.Category;
            model.ImageUrl = item.ImageUrl;


            model.Tags = item.ProductTags.Select(j => j.Tag).ToList();



            products.Add(model);

        }

        return products;
    }

    public async Task<bool> CreateTagsAsync(AddTagsViewModel addTagsViewModel)
    {
        try
        {
            TagEntity tagEntity = addTagsViewModel;

            _context.Add(tagEntity);
            await _context.SaveChangesAsync();
            return true;
        } 
        catch
        {
            return false;
        }


    }

    public async Task AddProductTagsAsync(ProductEntity entity, string[] tags)
    {
        foreach(var tag in tags)
        {
            await _productTagRepo.AddAsync(new ProductTagEntity
            {
                ArticleNumber = entity.ArticleNumber,
                TagId = int.Parse(tag)
            });
        }
    }

    public async Task<bool> UploadImageAsync(Product product, IFormFile image) 
    {
        try
        {
            string imagePath = $"{_webHostEnvironment.WebRootPath}/images/products/{product.ImageUrl}";

            await image.CopyToAsync(new FileStream(imagePath, FileMode.Create));
            return true;
        }
        catch { return false; }
    }
}