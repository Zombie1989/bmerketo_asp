using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.ViewModels.Account;

public class SignUpViewModel
{
    [Display(Name = "First Name")]
    [Required(ErrorMessage = "You must provide a first name")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "You must provide a last name")]
    public string LastName { get; set; } = null!;

    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must provide a legit e-mail")]
    //[RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([azA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "You must provide a valid e-mail address.")]
    public string Email { get; set; } = null!;

    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "You must provide a legit password")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Your password need to contain upper and lower case letter, you need also to have atleast one number and a special character.")]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    [Required(ErrorMessage = "You must confirm your password")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Company")]
    public string? Company { get; set; }

    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Street Name")]
    [Required(ErrorMessage = "You must provide a street name")]
    public string StreetName { get; set; } = null!;

    [Display(Name = "City")]
    [Required(ErrorMessage = "You must provide a city")]
    public string City { get; set; } = null!;

    [Display(Name = "Postal Code")]
    [Required(ErrorMessage = "You must provide a postal code")]
    public string PostalCode { get; set; } = null!;

    [Display(Name = "Upload Profile Image")]
    [DataType(DataType.Upload)]
    public IFormFile? ImageFile { get; set; }


    [Display(Name = "I have read and accept the terms and agreements")]
    [Required(ErrorMessage = "You must agree to terms and conditions")]
    public bool TermsAndAgreement { get; set; } = false;


    public static implicit operator AppUser(SignUpViewModel model)
    {
        return new AppUser
        {
            UserName = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            CompanyName = model.Company
        };
    }

    public static implicit operator AddressEntity(SignUpViewModel model)
    {
        return new AddressEntity
        {
            StreetName = model.StreetName,
            City = model.City,
            PostalCode = model.PostalCode,
        };
    }
}
