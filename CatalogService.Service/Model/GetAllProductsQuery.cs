using MediatR;

namespace CatalogService.Service.Model;
public class GetAllProductsQuery : IRequest<List<Products>> { }