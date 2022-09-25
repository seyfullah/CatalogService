using CatalogService.Service.Model;

namespace CatalogService.Service.Service;

public interface IProductService
{
    public Task<IEnumerable<Products>> GetProducts();
    public Task<Products>? GetProduct(long id);
    public Task<string> UpdateProduct(long id, Products product);

    public Task<Products> CreateProduct(Products product);
    public Task<long> DeleteProduct(long id);

    public bool ProductExists(long id);

}