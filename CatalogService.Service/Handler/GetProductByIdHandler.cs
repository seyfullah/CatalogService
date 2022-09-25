using CatalogService.Service.Model;
using CatalogService.Service.Service;
using MediatR;

namespace CatalogService.Service.Handler;
public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Products>
{
    private readonly IProductService _productService;

	public GetProductByIdHandler(IProductService productService)
	{
		_productService = productService;
	}

    public async Task<Products> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
		var product = await _productService.GetProduct(request.Id);
		return product;
    }
}