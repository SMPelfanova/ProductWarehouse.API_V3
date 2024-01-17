namespace ProductWarehouse.UnitTests.InfrastructureTests;

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using ProductWarehouse.Infrastructure.Http;
using Xunit;

public class MockyClientServiceTests
{
    [Fact]
    public async Task GetProductListAsync_ReturnsProducts_WhenResponseIsSuccessful()
    {
        // Arrange
        var httpClient = CreateHttpClient(HttpStatusCode.OK, "[{ \"Title\": \"Product1\", \"Price\": 10.0, \"Sizes\": [\"Small\"] }]");
        var loggerMock = new Mock<ILogger<MockyClientService>>();
        var mockyClientService = new MockyClientService(httpClient, loggerMock.Object);
        var productUri = new Uri("http://example.com/products");

        // Act
        var products = await mockyClientService.GetProductListAsync(productUri);

        // Assert
        Assert.NotNull(products);
        Assert.Single(products);
        Assert.Equal("Product1", products[0].Title);
        Assert.Equal(10.0m, products[0].Price);
        Assert.Contains("Small", products[0].Sizes);
    }

    [Fact]
    public async Task GetProductListAsync_ReturnsEmptyList_WhenResponseIsNotSuccessful()
    {
        // Arrange
        var httpClient = CreateHttpClient(HttpStatusCode.NotFound, string.Empty);
        var loggerMock = new Mock<ILogger<MockyClientService>>();
        var mockyClientService = new MockyClientService(httpClient, loggerMock.Object);
        var productUri = new Uri("http://example.com/products");

        // Act
        var products = await mockyClientService.GetProductListAsync(productUri);

        // Assert
        Assert.NotNull(products);
        Assert.Empty(products);
    }

    private static HttpClient CreateHttpClient(HttpStatusCode statusCode, string content)
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = statusCode,
                Content = new StringContent(content)
            });

        return new HttpClient(handlerMock.Object);
    }
}
