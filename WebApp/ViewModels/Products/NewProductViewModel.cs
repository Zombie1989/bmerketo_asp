using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels.Products;

public class NewProductViewModel
{
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

    [Display(Name = "Add product image url")]
    public string? ImageUrl { get; set; }



    public static implicit operator ProductEntity(NewProductViewModel newProductViewModel)
    {
        return new ProductEntity
        {
            Name = newProductViewModel.Name,
            Description = newProductViewModel.Description,
            Category = newProductViewModel.Category,
            Price = newProductViewModel.Price,
            ImageUrl = newProductViewModel.ImageUrl,
        };
    }
}
