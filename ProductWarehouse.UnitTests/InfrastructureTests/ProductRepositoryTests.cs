using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Infrastructure.Repositories;
using System.Net;
using Xunit;

public class ProductRepositoryTests
{
    [Fact]
    public async Task GetProductsAsync_ReturnsFilteredProducts()
    {
        // Arrange
        string testLink = "https://testlink";
        var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(httpMessageHandlerMock.Object);
        var configurationMock = new Mock<IConfiguration>();
        var loggerMock = new Mock<ILogger<ProductRepository>>();

        configurationMock.Setup(x => x.GetSection("ProductSourceSettings:ProductListURL").Value)
                         .Returns(testLink);

        var expectedProducts = new List<Product>
        {
            new Product { /* Set properties for the first product */ },
            new Product { /* Set properties for the second product */ },
            // Add more sample products as needed
        };

        var jsonString = JsonConvert.SerializeObject(expectedProducts);

        httpMessageHandlerMock
         .Protected()
         .Setup<Task<HttpResponseMessage>>(
             "SendAsync",
             ItExpr.IsAny<HttpRequestMessage>(),
             ItExpr.IsAny<CancellationToken>()
         )
         .ReturnsAsync(new HttpResponseMessage
         {
             Content = new StringContent(jsonString),
             StatusCode = HttpStatusCode.OK,
         });

        var productRepository = new ProductRepository(httpClient, loggerMock.Object, configurationMock.Object);

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
