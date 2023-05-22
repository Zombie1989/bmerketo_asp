using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Models.Identity;
using WebApp.Repositories;
using WebApp.Services.Account;
using WebApp.Services.Admin;
using WebApp.Services.Contacts;
using WebApp.Services.Home;
using WebApp.Services.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<SaleService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<SeedService>();
builder.Services.AddScoped<ContactService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TagService>();

builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<TagRepo>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<ProductTagRepository>();


builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;

})
    .AddEntityFrameworkStores<IdentityContext>()
    .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";
});

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityUser")));



var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
