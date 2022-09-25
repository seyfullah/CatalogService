using CatalogService.Service.Model;
using CatalogService.Service.Service;
using MediatR;

namespace CatalogService.Service.Handler;

public class AddProductHandler : IRequestHandler<AddProductCommand, Products>
{
    private readonly IProductService _productService;

    public AddProductHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<Products> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Products
        {
            Name = request.Name,
            Price = request.Price,
            Cost = request.Cost,
            Image = request.Image
        };
        return await _productService.CreateProduct(product);
    }
}