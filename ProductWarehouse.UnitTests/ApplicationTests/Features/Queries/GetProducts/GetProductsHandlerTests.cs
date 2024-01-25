using FakeItEasy;
using FluentAssertions;
using FluentValidation;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Application.Features.Queries.GetProducts;
using ProductWarehouse.Domain.Entities;
using Serilog;
using Xunit;

namespace ProductWarehouse.UnitTests.ApplicationTests.Features.Queries.GetProducts;

public class GetProductsHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsExpectedResponse()
    {
        // Arrange
        var productRepositoryMock = A.Fake<IProductRepository>();
        var validatorMock = A.Fake<IValidator<GetAllProductsQuery>>();
        A.CallTo(() => validatorMock.Validate(A<GetAllProductsQuery>._)).Returns(new FluentValidation.Results.ValidationResult());
        var mapperMock = TestStartup.CreateMapper();
        var loggerMock = A.Fake<ILogger>();

        var productsQuery = new GetAllProductsQuery
        {
            MinPrice = 10,
            MaxPrice = 100,
            Size = "Medium",
            Highlight = "keyword1, keyword2"
        };

        var products = new List<Product>
        {
            new Product { Title = "Test", Description = "test", Price = 10 },
            new Product { Title = "Test 2", Description = "test 2", Price = 11 }
        };

        A.CallTo(() => productRepositoryMock.GetAllAsync())
                             .Returns(products);

        var handler = new GetAllProductsQueryHandler(productRepositoryMock, mapperMock, validatorMock, loggerMock);

        // Act
        var result = await handler.Handle(productsQuery, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
    }
}
