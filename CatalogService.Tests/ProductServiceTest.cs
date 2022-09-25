namespace CatalogService.Tests;

public class ProductServiceTest
{
    [Fact]
    public async void GetProducts_ShouldHaveFiveItems()
    {
        // Arrange
        var productService = new FakeProductService();
        // Act
        var products = await productService.GetProducts();
        // Assert
        Assert.Equal(5, products.Count());
    }
}