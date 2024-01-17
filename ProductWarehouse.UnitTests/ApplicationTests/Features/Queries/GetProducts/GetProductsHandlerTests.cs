using Microsoft.Extensions.Logging;
using Moq;
using ProductWarehouse.Application.Contracts;
using ProductWarehouse.Application.Features.Queries.GetProducts;
using ProductWarehouse.Domain.Entities;
using Xunit;

namespace ProductWarehouse.UnitTests.ApplicationTests.Features.Queries.GetProducts;

public class GetProductsHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsExpectedResponse()
    {
        // Arrange
        var productRepositoryMock = new Mock<IProductRepository>();
        var mapperMock = TestStartup.CreateMapper();
        var loggerMock = new Mock<ILogger<GetProductsHandler>>();

        var productsQuery = new ProductsQuery
        {
            MinPrice = 10,
            MaxPrice = 100,
            Size = "Medium",
            Highlight = "keyword1, keyword2"
        };

        var products = new List<Product>
        {
            new Product { Title = "Test", Description = "test", Price = 10, Sizes = new List<string>{ "Small" } },
            new Product { Title = "Test 2", Description = "test 2", Price = 10, Sizes = new List<string>{ "Medium" } }
        };

        productRepositoryMock.Setup(repo => repo.GetProductsAsync(productsQuery.MinPrice, productsQuery.MaxPrice, productsQuery.Size))
                             .ReturnsAsync(products);

        var handler = new GetProductsHandler(productRepositoryMock.Object, mapperMock, loggerMock.Object);

        // Act
        var result = await handler.Handle(productsQuery, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Products);
        Assert.Equal(products.Count(), result.Products.Count());
    }

}
