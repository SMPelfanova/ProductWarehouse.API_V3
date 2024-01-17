using FakeItEasy;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.Logging;
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
        var productRepositoryMock = A.Fake<IProductRepository>();
        var validatorMock = A.Fake<IValidator<ProductsQuery>>();
        A.CallTo(() => validatorMock.Validate(A<ProductsQuery>._)).Returns(new FluentValidation.Results.ValidationResult());
        var mapperMock = TestStartup.CreateMapper();
        var loggerMock = A.Fake<ILogger<GetProductsHandler>>();

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

        A.CallTo(() => productRepositoryMock.GetProductsAsync(productsQuery.MinPrice, productsQuery.MaxPrice, productsQuery.Size))
                             .Returns(products);

        var handler = new GetProductsHandler(productRepositoryMock, mapperMock, validatorMock, loggerMock);

        // Act
        var result = await handler.Handle(productsQuery, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Products.Should().NotBeNull().And.HaveCount(2);
        products.Count().Should().Be(result.Products.Count());
    }

}
