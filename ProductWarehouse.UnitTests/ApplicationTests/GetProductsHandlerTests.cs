using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using ProductWarehouse.Application.Queries;
using ProductWarehouse.Application.QueryHandlers;
using ProductWarehouse.Application.Responses;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Domain.Repositories;
using Xunit;

namespace ProductWarehouse.UnitTests.ApplicationTests
{
    public class GetProductsHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsExpectedResponse()
        {
            // Arrange
            var productRepositoryMock = new Mock<IProductRepository>();
            var mapperMock = new Mock<IMapper>();
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
            new Product { /* create sample product 1 */ },
            new Product { /* create sample product 2 */ }
        };

            productRepositoryMock.Setup(repo => repo.GetProductsAsync(productsQuery.MinPrice, productsQuery.MaxPrice, productsQuery.Size))
                                 .ReturnsAsync(products);

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<ProductResponse>>(It.IsAny<IEnumerable<Product>>()))
                      .Returns((IEnumerable<Product> source) => source.Select(p => new ProductResponse { /* map properties */ }));

            var handler = new GetProductsHandler(productRepositoryMock.Object, mapperMock.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(productsQuery, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Products);
            Assert.Equal(products.Count(), result.Products.Count());

            // Add more assertions based on your specific expectations for the response
        }

    }
}
