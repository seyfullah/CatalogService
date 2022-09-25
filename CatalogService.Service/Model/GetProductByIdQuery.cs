using MediatR;

namespace CatalogService.Service.Model;
public class GetProductByIdQuery : IRequest<Products>
{
	public long Id { get; }

    public GetProductByIdQuery(long id)
    {
        Id = id;
    }
}