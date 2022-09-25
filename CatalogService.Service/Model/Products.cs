using System.ComponentModel.DataAnnotations;

namespace CatalogService.Service.Model;
public class Products
{
    [Key]
    public long ProductId { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public decimal Cost { get; set; }
    public string? Image { get; set; }

}
