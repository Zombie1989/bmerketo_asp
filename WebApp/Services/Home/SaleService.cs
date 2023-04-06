using WebApp.Models.Home;

namespace WebApp.Services.Home;

public class SaleService
{
    private readonly List<SaleModel> _sales = new()
    {
        new SaleModel
        {
            Title = "UP TO SALE",
            PriceOff = "50% OFF",
            TextTitle = "Get The Best Price",
            Text = "Get the best daily offer Lorem ipsum dolor sit amet consectetur adipisicing elit. Doloribus officia aliquid, mollitia deleniti laboriosam dignissimos.",
        }
    };

    public SaleModel GetLatest()
    {
        return _sales.LastOrDefault()!;
    }

}
