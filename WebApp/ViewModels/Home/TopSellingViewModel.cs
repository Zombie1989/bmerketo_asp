namespace WebApp.ViewModels.Home;

public class TopSellingViewModel
{
    public string Title { get; set; } = "";
    public IEnumerable<GridCollectionItemViewModel> TopItems { get; set; } = null!;
}
