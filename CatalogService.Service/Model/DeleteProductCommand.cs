using MediatR;

namespace CatalogService.Service.Model;

public class DeleteProductCommand : IRequest<long>
{
    public long ProductId { get; set; } 

    public DeleteProductCommand(long productId)
    {
        ProductId = productId;
    }
}