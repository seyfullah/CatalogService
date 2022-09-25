using CatalogService.Service.Model;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Service.Service;

public interface IProductRepository { }
public class ProductDb : DbContext, IProductRepository
{
    public ProductDb(DbContextOptions<ProductDb> options)
     : base(options)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "Products.db");
    }

    public DbSet<Products> Products => Set<Products>();

    public string DbPath { get; }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

}