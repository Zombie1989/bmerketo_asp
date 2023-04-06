using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; } 
    public string? ImageUrl { get; set; }
}
