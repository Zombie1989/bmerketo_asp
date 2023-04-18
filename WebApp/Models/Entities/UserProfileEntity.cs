using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Entities;

public class UserProfileEntity
{
    [Key, ForeignKey(nameof(User))]
    public string UserId { get; set; } = null!;

    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [StringLength(100)]
    public string? Company { get; set; }

    [StringLength(100)]
    public string StreetName { get; set; } = null!;

    [StringLength(100)]
    public string City { get; set; } = null!;

    [StringLength(6)]
    public string PostalCode { get; set; } = null!;
    public string? ProfileImage { get; set; }

    public IdentityUser User { get; set; } = null!;
}
