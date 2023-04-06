namespace WebApp.ViewModels.Home
{
    public class ItemSaleViewModel
    {
        public string Title { get; set; } = "";
        public string PriceOff { get; set; } = "";
        public string TextTitle { get; set; } = "";
        public string Text { get; set; } = "";
        public IEnumerable<GridCollectionItemViewModel> ItemSale { get; set; } = null!;
    }
}
