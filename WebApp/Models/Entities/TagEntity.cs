using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities;

public class TagEntity
{
    [Key]
    public int Id { get; set; }
    public string? TagName { get; set; }

}
