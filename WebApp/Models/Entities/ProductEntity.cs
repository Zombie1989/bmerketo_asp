﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.Products;

namespace WebApp.Models.Entities;

public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Category { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; } 
    public string? ImageUrl { get; set; }


    public static implicit operator ProductModel(ProductEntity entity)
    {
        return new ProductModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Category = entity.Category,
            Price = entity.Price,
            ImageUrl = entity.ImageUrl,
        };
    }
}
