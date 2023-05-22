using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels.Products;

public class NewProductViewModel
{
    [Required(ErrorMessage = "You need to add the articlenumber")]
    [Display(Name = "Articlenumber")]
    public string ArticleNumber { get; set; } = null!;

    [Required(ErrorMessage = "You need to add the productname")]
    [Display(Name = "Productname*")]
    public string Name { get; set; } = null!;

    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Display(Name = "Category name")]
    public string? Category { get; set; }

    [Required(ErrorMessage = "You need to add a price")]
    [Display(Name = "Product price*")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }

    [Display(Name = "Add product image file")]
    [DataType(DataType.Upload)]
    public IFormFile? Image { get; set; }



    public static implicit operator ProductEntity(NewProductViewModel newProductViewModel)
    {
        var entity = new ProductEntity
        {
            ArticleNumber = newProductViewModel.ArticleNumber,
            Name = newProductViewModel.Name,
            Description = newProductViewModel.Description,
            Category = newProductViewModel.Category,
            Price = newProductViewModel.Price,
        };

        if (newProductViewModel.Image != null)
            entity.ImageUrl = $"{newProductViewModel.ArticleNumber}_{newProductViewModel.Image?.FileName}";

        return entity;
            
    }
}
