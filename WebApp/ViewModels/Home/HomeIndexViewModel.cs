namespace WebApp.ViewModels.Home;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "Home";
    public GridCollectionViewModel BestCollection { get; set; } = null!;
    public ItemSaleViewModel ItemSales { get; set; } = null!;
    public TopSellingViewModel TopSales { get; set; } = null!;
    public PostCollectionViewModel Posts { get; set; } = null!;
}
