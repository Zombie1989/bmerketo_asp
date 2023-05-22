using WebApp.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositories;

public class TagRepo : ProductRepo<TagEntity>
{
    public TagRepo(DataContext context) : base(context)
    {
    }
}
