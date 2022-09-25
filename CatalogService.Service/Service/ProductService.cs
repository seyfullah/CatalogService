using Microsoft.EntityFrameworkCore;

using CatalogService.Service.Model;
using CatalogService.Helper;

namespace CatalogService.Service.Service;
public class ProductService : IProductService
{
    private readonly ProductDb _context;
    public ProductService(ProductDb context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Products>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Products>? GetProduct(long id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
        {
            return null;
        }

        return product;
    }

    public async Task<Products> CreateProduct(Products product)
    {
        ProducerHelper.NotifyForNewProduct(product);
        _context.Products.Add(product);
        var id = await _context.SaveChangesAsync();
        product.ProductId = id;
        return product;
    }

    public async Task<string> UpdateProduct(long id, Products product)
    {
        _context.Entry(product).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductExists(id))
            {
                return new string("NotFound");
            }
            else
            {
                throw;
            }
        }

        return new string("NoContent");
    }

    public async Task<long> DeleteProduct(long id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return -1;//new string("NotFound");
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return 0;//new string("NoContent");
    }

    public bool ProductExists(long id)
    {
        return _context.Products.Any(e => e.ProductId == id);
    }
}
