using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels.Contacts;

public class ContactFormViewModel
{

    [Display(Name = "Name")]
    [Required(ErrorMessage = "You must write your name")]
    public string Name { get; set; } = null!;

    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "You must provide a legit e-mail")]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone Number")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Company")]
    public string? Company { get; set; }

    [Display(Name = "Text")]
    public string TextForm { get; set; } = null!;


    public bool RememberMe { get; set; } = false!;


    public static implicit operator ContactFormEntity(ContactFormViewModel contactFormViewModel)
    {
        return new ContactFormEntity
        {
            Name = contactFormViewModel.Name,
            Email = contactFormViewModel.Email,
            PhoneNumber = contactFormViewModel.PhoneNumber,
            Company = contactFormViewModel.Company,
            TextForm = contactFormViewModel.TextForm,
        };
    }
}
