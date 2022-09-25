using MediatR;

namespace CatalogService.Service.Model;

public class UpdateProductCommand : IRequest<Products>
{
    public long ProductId { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public decimal Cost { get; set; }
    public string? Image { get; set; }

    public UpdateProductCommand(Products product)
    {
        ProductId = product.ProductId;
        Name = product.Name;
        Price = product.Price;
        Cost = product.Cost;
        Image = product.Image;
    }
}