using WebApp.Models.Entities;

namespace WebApp.ViewModels.Admin
{

    public class UserViewModel
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? PhoneNumber { get; set; }
        public string StreetName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

        public IList<string> Roles { get; set; } = null!;

        


        public static implicit operator AddressEntity(UserViewModel model)
        {
            return new AddressEntity
            {
                StreetName = model.StreetName,
                City = model.City,
                PostalCode = model.PostalCode,
            };
        }

    }
}
