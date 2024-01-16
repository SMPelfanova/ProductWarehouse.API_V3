﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using ProductWarehouse.Application.Features.Queries.GetProducts;
using ProductWarehouse.Application.Models;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Infrastructure.Interfaces;
using Xunit;

namespace ProductWarehouse.UnitTests.ApplicationTests.QueryHandlers
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
                new Product { Title = "Test", Description = "test", Price = 10, Sizes = new List<string>{ "Small" } },
                new Product { Title = "Test 2", Description = "test 2", Price = 10, Sizes = new List<string>{ "Medium" } }
            };

            productRepositoryMock.Setup(repo => repo.GetProductsAsync(productsQuery.MinPrice, productsQuery.MaxPrice, productsQuery.Size))
                                 .ReturnsAsync(products);

            mapperMock.Setup(mapper => mapper.Map<IEnumerable<ProductDto>>(It.IsAny<IEnumerable<Product>>()))
                      .Returns((IEnumerable<Product> source) => source.Select(p => new ProductDto{ /* map properties */ }));

            var handler = new GetProductsHandler(productRepositoryMock.Object, mapperMock.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(productsQuery, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            //Assert.NotNull(result.Products);
            Assert.Equal(products.Count(), result.Count());
        }

    }
}
