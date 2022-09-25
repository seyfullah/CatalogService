using CatalogService.Service.Model;
using CatalogService.Service.Service;
using MediatR;

namespace CatalogService.Service.Handler;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, long>
{
    private readonly IProductService _productService;

    public DeleteProductHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<long> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var result = await _productService.DeleteProduct(request.ProductId);
        return result;
    }
}