using CatalogService.Service.Model;
using CatalogService.Service.Service;
using MediatR;

namespace CatalogService.Service.Handler;
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Products>>
{
    private readonly IProductService _productService;

    public GetAllProductsQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<List<Products>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productService.GetProducts();
        return products.ToList();
    }
}