using Microsoft.Extensions.Logging;
using Moq;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Infrastructure.Data;
using ProductWarehouse.Infrastructure.Repositories;
using Xunit;

public class ProductRepositoryTests
{
    [Fact]
    public async Task GetProductsAsync_ReturnsFilteredProducts()
    {
        // Arrange
        var httpClientMock = new Mock<HttpClient>();
        var loggerMock = new Mock<ILogger<ProductRepository>>();
        var productDbContext = new ProductDbContext(httpClientMock.Object, loggerMock.Object);
        var productRepository = new ProductRepository(productDbContext);

        var minPrice = 10m;
        var maxPrice = 100m;
        var size = "Medium";

        var productsInDatabase = new List<Product>
        {
            new Product { /* create sample product 1 */ },
            new Product { /* create sample product 2 */ },
            // Add more sample products as needed
        };


        // Act
        var result = await productRepository.GetProductsAsync(minPrice, maxPrice, size);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.All(p =>
            (minPrice == 0 || p.Price >= minPrice) &&
            (maxPrice == 0 || p.Price <= maxPrice) &&
            (string.IsNullOrEmpty(size) || p.Sizes.Any(s => s.ToLowerInvariant() == size.ToLowerInvariant()))
        ));
    }

    // Add more test cases to cover different scenarios, such as empty products, null parameters, etc.
}
