﻿namespace WebApp.ViewModels.Products;

public class NewProductViewModel
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; } 
    public string? ImageUrl { get; set; }
}
