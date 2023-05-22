using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models.Identity;
using WebApp.ViewModels.Admin;

namespace WebApp.Services.Admin;

public class UserService
{
    private readonly IdentityContext _context;
    private readonly UserManager<AppUser> _userManager;


    public UserService(IdentityContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IEnumerable<UserViewModel>> GetUserAsync()
    {
        var users = await _context.Users.Include(x => x.Addresses).ThenInclude(j => j.Address).ToListAsync();

        var userViewModels = new List<UserViewModel>();
        foreach (var user in users)
        {
            var userViewModel = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                CompanyName = user.CompanyName,
                PhoneNumber = user.PhoneNumber,
                StreetName = user.Addresses.FirstOrDefault()?.Address.StreetName!,
                City = user.Addresses.FirstOrDefault()?.Address.City!,
                PostalCode = user.Addresses.FirstOrDefault()?.Address.PostalCode!
            };

            var roles = await _userManager.GetRolesAsync(user);
            userViewModel.Roles = roles;

            userViewModels.Add(userViewModel);
        }

        return userViewModels;
        
    }


}