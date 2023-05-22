using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.ViewModels.Contacts;

namespace WebApp.Services.Contacts;

public class ContactService
{
    private readonly DataContext _context;

    public ContactService(DataContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(ContactFormViewModel contactFormViewModel)
    {
        try
        {
            ContactFormEntity contactFormEntity = contactFormViewModel;

            _context.Add(contactFormEntity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
    
}
