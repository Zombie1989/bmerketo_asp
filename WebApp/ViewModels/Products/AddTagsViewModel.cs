using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels.Products;

public class AddTagsViewModel
{
    [Required(ErrorMessage = "You need to add the tagname")]
    [Display(Name = "Tag Title")]
    public string Title { get; set; } = null!;


    public static implicit operator TagEntity(AddTagsViewModel addTagsViewModel)
    {
        return new TagEntity
        {
            TagName = addTagsViewModel.Title,
        };
    }
}
