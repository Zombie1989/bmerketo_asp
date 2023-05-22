using WebApp.Models.Entities;

namespace WebApp.Models.Products
{
    public class ProductModel
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }


        public ICollection<TagEntity> Tags { get; set; } = new HashSet<TagEntity>();
    }
}
