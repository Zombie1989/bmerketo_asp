using WebApp.Contexts;
using WebApp.Models.Identity;

namespace WebApp.Repositories;

public class UserRepo : Repository<AppUser>
{
    public UserRepo(IdentityContext context) : base(context)
    {
    }

}
