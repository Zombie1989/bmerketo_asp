using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Dtos;

public class Product
{
    [Key]
    public string ArticleNumber { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Category { get; set; }

    [Column(TypeName = "Money")]
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
}
