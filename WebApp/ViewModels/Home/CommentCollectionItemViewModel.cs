namespace WebApp.ViewModels.Home;

public class CommentCollectionItemViewModel
{
    public string Id { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
    public string? Comments { get; set; }
}
