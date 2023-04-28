using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.Models.Identity;
using WebApp.ViewModels.Account;

namespace WebApp.Services.Account;

public class AuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly AddressService _addressService;
    private readonly IdentityContext _identityContext;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SeedService _seedService;

    public AuthService(UserManager<AppUser> userManager, IdentityContext identityContext, AddressService addressService, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, SeedService seedService)
    {
        _userManager = userManager;
        _identityContext = identityContext;
        _addressService = addressService;
        _signInManager = signInManager;
        _roleManager = roleManager;
        _seedService = seedService;
    }

    public async Task<bool> SignUpAsync(SignUpViewModel model)
    {
        try
        {
            await _seedService.SeedRoles();
            var roleName = "user";

            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";



            AppUser appUser = model;

            var result = await _userManager.CreateAsync(appUser, model.Password);

            await _userManager.AddToRoleAsync(appUser, roleName);

            if (result.Succeeded)
            {

                var addressEntity = await _addressService.GetOrCreateAsync(model);
                if (addressEntity != null)
                {
                    await _addressService.AddAddressAsync(appUser, addressEntity);
                    return true;
                }
            }

            return false;

        } catch { return false; }
    }

    public async Task<bool> UserAlreadyExistsAsync(Expression<Func<AppUser, bool>> expression)
    {
        return await _userManager.Users.AnyAsync(expression);
    }

    public async Task<bool> LoginAsync(LoginViewModel model)
    {
        var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
        if (appUser != null)
        {
            var result = await _signInManager.PasswordSignInAsync(appUser, model.Password, model.RememberMe, false);
            return result.Succeeded;
        }
        return false;
    }
}
