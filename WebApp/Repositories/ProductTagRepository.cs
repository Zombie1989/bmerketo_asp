using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositories;

public class ProductTagRepository : ProductRepo<ProductTagEntity>
{
    public ProductTagRepository(DataContext context) : base(context)
    {
    }
}
