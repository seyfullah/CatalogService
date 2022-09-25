using CatalogService.Service.Model;
using CatalogService.Service.Service;

namespace CatalogService.Tests;

public class FakeProductService : IProductService
{
    private readonly List<Products> _products;
    public FakeProductService()
    {
        _products = new List<Products>
            {
                new Products {ProductId = 1, Name = "Apple", Price = 10, Cost = 5, Image = "qwe" },
                new Products {ProductId = 2, Name = "Orange", Price = 11, Cost = 6, Image = "asd" },
                new Products {ProductId = 3, Name = "Banana", Price = 12, Cost = 7, Image = "zxc" },
                new Products {ProductId = 4, Name = "Cake", Price = 13, Cost = 8, Image = "wer" },
                new Products {ProductId = 5, Name = "PAsta", Price = 14, Cost = 9, Image = "sdf" },
            };
    }


    private async Task<IEnumerable<Products>> GetProductsAsync()
    {
        await Task.Delay(10);
        return _products;
    }

    public async Task<IEnumerable<Products>> GetProducts()
    {
        var products = await GetProductsAsync();
        return products;
    }

    public Task<Products>? GetProduct(long id)
    {
        throw new NotImplementedException();
    }

    public Task<string> UpdateProduct(long id, Products product)
    {
        throw new NotImplementedException();
    }

    public Task<Products> CreateProduct(Products product)
    {
        throw new NotImplementedException();
    }

    public Task<long> DeleteProduct(long id)
    {
        throw new NotImplementedException();
    }

    public bool ProductExists(long id)
    {
        throw new NotImplementedException();
    }
}