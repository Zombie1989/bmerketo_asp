using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.Dtos;
using WebApp.Models.Products;

namespace WebApp.Models.Entities;

public class ProductEntity
{
    [Key]
    public string ArticleNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Category { get; set; }

    [Column(TypeName = "Money")]
    public decimal Price { get; set; } 
    public string? ImageUrl { get; set; }


    public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();


    public static implicit operator ProductModel(ProductEntity entity)
    {
        return new ProductModel
        {
            Id = entity.ArticleNumber,
            Name = entity.Name,
            Description = entity.Description,
            Category = entity.Category,
            Price = entity.Price,
            ImageUrl = entity.ImageUrl,
        };
    }

    public static implicit operator Product(ProductEntity entity)
    {
        return new Product
        {
            ArticleNumber = entity.ArticleNumber,
            Name = entity.Name,
            Description = entity.Description,
            Category = entity.Category,
            Price = entity.Price,
            ImageUrl = entity.ImageUrl,
        };
    }
}
