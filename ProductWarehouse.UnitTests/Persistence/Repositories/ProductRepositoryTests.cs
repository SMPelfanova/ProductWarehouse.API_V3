using AutoFixture.AutoMoq;
using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using ProductWarehouse.Infrastructure.Http;
using ProductWarehouse.Persistence.Repositories;
using Xunit;
using Microsoft.Extensions.Options;
using ProductWarehouse.Infrastructure.Configuration;
using Microsoft.Extensions.Logging;

namespace ProductWarehouse.UnitTests.Persistence.Repositories;

public class ProductRepositoryTests
{
    [Fact]
    public async Task GetProductsAsync_ReturnsNoResult()
    {
        // Arrange
        var fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization());

        var httpClient = A.Fake<HttpClient>();
        var loggerMock = A.Fake<ILogger<MockyClientService>>();
        var configMock = A.Fake<IOptions<MockyClientOptions>>();
        A.CallTo(() => configMock.Value).Returns(new MockyClientOptions
        {
            BaseUrl = "http://example.com",
            ProductUrl = "/products"
        });
        var mockyClientService = new MockyClientService(httpClient, loggerMock, configMock);

        var repository = new ProductRepository(mockyClientService);

        // Act
        var result = await repository.GetProductsAsync(null, null, null);

        // Assert
        result.Should().BeEmpty();
    }
}