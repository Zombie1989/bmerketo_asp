using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.Contexts
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }





        public DbSet<AddressEntity> AddressEntities { get; set; }
        public DbSet<UserAddressEntity> UserAddresses { get; set; }

      /*  protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });

            var passwordHasher = new PasswordHasher<AppUser>();

            builder.Entity<AppUser>().HasData(new AppUser
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Admin",
                PasswordHash = passwordHasher.HashPassword(null!, "Bytmig123!"),
            });

            builder.Entity<IdentityRole>().HasData(new IdentityUserRole<>
            {
                
            }); 
        } */
    }
}
