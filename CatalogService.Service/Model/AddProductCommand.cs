using MediatR;

namespace CatalogService.Service.Model;

public class AddProductCommand : IRequest<Products>
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public decimal Cost { get; set; }
    public string? Image { get; set; }

    public AddProductCommand(Products product)
    {
        Name = product.Name;
        Price = product.Price;
        Cost = product.Cost;
        Image = product.Image;
    }
}