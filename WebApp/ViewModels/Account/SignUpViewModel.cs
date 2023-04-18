using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels.Account;

public class SignUpViewModel
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; } = null!;

    public string? Company { get; set; }
    public string? PhoneNumber { get; set; }
    public string StreetName { get; set; } = null!; 
    public string City { get; set; } = null!; 
    public string PostalCode { get; set; } = null!;
    public string? ProfileImage { get; set; }


    public string DisplayName => $"{FirstName} {LastName}";



    public static implicit operator IdentityUser(SignUpViewModel model)
    {
        return new IdentityUser
        {
            UserName = model.DisplayName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
        };
    }

    public static implicit operator UserProfileEntity(SignUpViewModel model)
    {
        return new UserProfileEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            StreetName = model.StreetName,
            City = model.City,
            PostalCode = model.PostalCode,
        };
    }
}
