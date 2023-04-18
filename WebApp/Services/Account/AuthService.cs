using Microsoft.AspNetCore.Identity;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.ViewModels.Account;

namespace WebApp.Services.Account;

public class AuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IdentityContext _identityContext;

    public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext)
    {
        _userManager = userManager;
        _identityContext = identityContext;
    }

    public async Task<bool> SignUpAsync(SignUpViewModel model)
    {
        try
        {
            IdentityUser identityUser = model;
            await _userManager.CreateAsync(identityUser, model.Password);

            UserProfileEntity userProfileEntity = model;
            userProfileEntity.UserId = identityUser.Id;

            _identityContext.UserProfiles.Add(userProfileEntity);
            await _identityContext.SaveChangesAsync();

            return true;
        }
        catch { return false; }
    }
}
