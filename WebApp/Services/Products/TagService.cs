using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Repositories;

namespace WebApp.Services.Products;

public class TagService
{
    private readonly TagRepo _tagRepo;

    public TagService(TagRepo tagRepo)
    {
        _tagRepo = tagRepo;
    }

    public async Task<List<SelectListItem>> GetTagsAsync()
    {
        var tags = new List<SelectListItem>();

        foreach (var tag in await _tagRepo.GetAllAsync())
        {
            tags.Add(new SelectListItem
            {
                Value = tag.Id.ToString(),
                Text = tag.TagName
            });
        }

        return tags;
    }


    public async Task<List<SelectListItem>> GetTagsAsync(string[]? selected = null)
    {
        var tags = new List<SelectListItem>();

        foreach (var tag in await _tagRepo.GetAllAsync())
        {
            tags.Add(new SelectListItem
            {
                Value = tag.Id.ToString(),
                Text = tag.TagName,
                Selected = selected!.Contains(tag.Id.ToString())
            });
        }

        return tags;
    }

    
}
