using AutoFixture.AutoMoq;
using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Infrastructure.Http;
using ProductWarehouse.Persistence.Repositories;
using Xunit;
using Microsoft.Extensions.Options;
using ProductWarehouse.Infrastructure.Configuration;

namespace ProductWarehouse.UnitTests.Persistence.Repositories
{
    public class ProductRepositoryTests
    {
        [Fact]
        public async Task GetProductsAsync_ReturnsAllProducts_WhenNoFilter()
        {   
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            var httpClientServiceMock = A.Fake<MockyClientService>();
            var mockOptions = A.Fake<IOptions<MockyClientConfiguration>>();
            A.CallTo(() => mockOptions.Value).Returns(new MockyClientConfiguration
            {
                BaseUrl = "http://example.com",
                ProductUrl = "/products"
            });

            var products = fixture.CreateMany<Product>(5);
            Uri uri = new Uri("http://example.com/products");
            A.CallTo(() => httpClientServiceMock.GetProductListAsync(uri)).Returns(products.ToList());

            var repository = new ProductRepository(httpClientServiceMock, mockOptions);

            // Act
            var result = await repository.GetProductsAsync(0, 0, string.Empty);

            // Assert
            result.Should().BeEquivalentTo(products);
        }

        [Fact]
        public async Task GetProductsAsync_ReturnsNoResult()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());
            var httpClientServiceMock = A.Fake<MockyClientService>();
            var mockOptions = A.Fake<IOptions<MockyClientConfiguration>>();
            A.CallTo(() => mockOptions.Value).Returns(new MockyClientConfiguration
            {
                BaseUrl = "http://example.com",
                ProductUrl = "/products"
            });

            var products = fixture.CreateMany<Product>(0);
            Uri uri = new Uri("http://example.com/products");
            A.CallTo(() => httpClientServiceMock.GetProductListAsync(uri)).Returns(products.ToList());

            var repository = new ProductRepository(httpClientServiceMock, mockOptions);

            // Act
            var result = await repository.GetProductsAsync(null, null, null);

            // Assert
            result.Should().BeEquivalentTo(products);
        }
    }
}