
namespace Taller1.Src.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public required int Stock { get; set; }
    public required int Price { get; set; } 
    public string Image { get; set; } = string.Empty;

}