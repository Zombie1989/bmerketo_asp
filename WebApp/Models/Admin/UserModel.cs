using WebApp.Models.Identity;

namespace WebApp.Models.Admin
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Company { get; set; }
        public string? PhoneNumber { get; set; }
        public string StreetName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode = null!;


    }
}
