using CatalogService.Service.Model;
using CatalogService.Service.Service;
using MediatR;

namespace CatalogService.Service.Handler;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Products>
{
    private readonly IProductService _productService;

    public UpdateProductHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<Products> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Products
        {
            ProductId = request.ProductId,
            Name = request.Name,
            Price = request.Price,
            Cost = request.Cost,
            Image = request.Image
        };
        await _productService.UpdateProduct(product.ProductId, product);
        return product;
    }
}