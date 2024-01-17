using AutoFixture.AutoMoq;
using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Infrastructure.Http;
using ProductWarehouse.Persistence.Repositories;
using Xunit;

namespace ProductWarehouse.UnitTests.Persistence.Repositories
{
    public class ProductRepositoryTests
    {
        [Fact]
        public async Task GetProductsAsync_ReturnsAllProducts_WhenNoFilter()
        {
            string baseUrl = "http://example.com";
            string productUrl = "/products";
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var httpClientServiceMock = fixture.Freeze<MockyClientService>();
            var fakeConfigSection = A.Fake<IConfigurationSection>();
            A.CallTo(() => fakeConfigSection["BaseUrl"])
                .Returns(baseUrl);

            var fakeConfig = A.Fake<IConfiguration>();
            A.CallTo(() => fakeConfig.GetSection("MockyClient"))
                .Returns(fakeConfigSection);

            //var configurationMock = A.Fake<IConfigurationRoot>();
            //A.CallTo(() => configurationMock.GetSection("MockyClient:BaseUrl").Value).Returns(baseUrl);
            //A.CallTo(() => configurationMock.GetSection("MockyClient:ProductUrl").Value).Returns(productUrl);

            var repository = new ProductRepository(httpClientServiceMock, fakeConfig);

            Uri baseUri = new Uri(baseUrl);
            Uri productUri = new Uri(baseUri, productUrl);
            var products = fixture.CreateMany<Product>(5);

            A.CallTo(() => httpClientServiceMock.GetProductListAsync(productUri)).Returns(products.ToList());

            // Act
            var result = await repository.GetProductsAsync(null, null, null);

            // Assert
            result.Should().BeEquivalentTo(products);
        }
    }
}