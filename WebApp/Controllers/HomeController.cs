using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels.Home;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var showcase = new HomeIndexViewModel
        {
            BestCollection = new GridCollectionViewModel
            {
                Title = "Best Collection",
                Categories = new List<string> { "All", "Bags", "Dress", "Decoration", "Essentials", "Interior", "Laptop", "Mobile", "Beauty" },
                GridItems = new List<GridCollectionItemViewModel>
                {
                    new GridCollectionItemViewModel { Id = "1", Title = "Apple watch collection", Price = 10, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "2", Title = "Apple watch collection", Price = 20, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "3", Title = "Apple watch collection", Price = 30, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "4", Title = "Apple watch collection", Price = 40, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "5", Title = "Apple watch collection", Price = 50, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "6", Title = "Apple watch collection", Price = 60, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "7", Title = "Apple watch collection", Price = 70, ImageUrl = "images/placeholders/270x295.svg" },
                    new GridCollectionItemViewModel { Id = "8", Title = "Apple watch collection", Price = 80, ImageUrl = "images/placeholders/270x295.svg" },
                }
            },

            ItemSales = new ItemSaleViewModel
            {
                ItemSale = new List<GridCollectionItemViewModel>
                {
                    new GridCollectionItemViewModel { Id = "9", Title = "Apple watch collection", Price = 90, ImageUrl = "images/placeholders/369x310.svg" },
                }
            },

            TopSales = new TopSellingViewModel
            {
                Title = "Top Selling Products This Week",
                TopItems = new List<GridCollectionItemViewModel>
                {
                   new GridCollectionItemViewModel { Id = "10", Title = "Apple watch collection", Price = 100, ImageUrl ="images/placeholders/270x295.svg" },
                   new GridCollectionItemViewModel { Id = "11", Title = "Apple watch collection", Price = 110, ImageUrl ="images/placeholders/270x295.svg" },
                   new GridCollectionItemViewModel { Id = "12", Title = "Apple watch collection", Price = 120, ImageUrl ="images/placeholders/270x295.svg" },
                   new GridCollectionItemViewModel { Id = "13", Title = "Apple watch collection", Price = 130, ImageUrl ="images/placeholders/270x295.svg" },
                   new GridCollectionItemViewModel { Id = "14", Title = "Apple watch collection", Price = 140, ImageUrl ="images/placeholders/270x295.svg" },
                   new GridCollectionItemViewModel { Id = "15", Title = "Apple watch collection", Price = 150, ImageUrl ="images/placeholders/270x295.svg" },
                }
            },

            Posts = new PostCollectionViewModel
            {
                PostItems = new List<PostCollectionItemViewModel>
                {

                    new PostCollectionItemViewModel { Id = "1", Title = "Table lamp 1562 LTG model", Info = "Best dress for everyone Lorem ipsum dolor sit amet consectetur, adipisicing elit. Accusantium, illum!", PostBy = "ADMIN", Comments = "13", ImageUrl = "images/placeholders/370x295.svg" },
                    new PostCollectionItemViewModel { Id = "2", Title = "Table lamp 1562 LTG model", Info = "Best dress for everyone Lorem ipsum dolor sit amet consectetur, adipisicing elit. Accusantium, illum!", PostBy = "ADMIN", Comments = "13", ImageUrl = "images/placeholders/370x295.svg" },
                    new PostCollectionItemViewModel { Id = "3", Title = "Table lamp 1562 LTG model", Info = "Best dress for everyone Lorem ipsum dolor sit amet consectetur, adipisicing elit. Accusantium, illum!", PostBy = "ADMIN", Comments = "13", ImageUrl = "images/placeholders/370x295.svg" }

                }
            }
        };

        return View(showcase);
    }
}
