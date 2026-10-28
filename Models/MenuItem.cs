using System.ComponentModel.DataAnnotations;
namespace MenuCatalogMini.Models;
public class MenuItem
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Въведете име.")][StringLength(100)][Display(Name="Име на ястието")] public string Name { get; set; } = "";
    [Required(ErrorMessage = "Изберете категория.")][StringLength(50)][Display(Name="Категория")] public string Category { get; set; } = "";
    [Range(typeof(decimal), "0.01", "999999", ErrorMessage = "Цената трябва да е положителна.")][Display(Name="Цена (лв.)")] public decimal Price { get; set; }
    [Range(1, 100000, ErrorMessage = "Грамажът трябва да е положителен.")][Display(Name="Грамаж (г)")] public int Grams { get; set; }
    [StringLength(1000)][Display(Name="Описание")] public string? Description { get; set; }
}
