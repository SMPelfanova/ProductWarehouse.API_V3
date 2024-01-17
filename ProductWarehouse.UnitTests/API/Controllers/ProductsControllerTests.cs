namespace ProductWarehouse.UnitTests.API.Controllers;

using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductWarehouse.API.Controllers;
using ProductWarehouse.API.Models.Requests;
using ProductWarehouse.API.Models.Responses;
using ProductWarehouse.Application.Features.Queries.GetProducts;
using ProductWarehouse.Application.Models;
using ProductWarehouse.UnitTests;
using Xunit;

public class ProductsControllerTests
{
    [Fact]
    public async Task GetProducts_ReturnsNotFound_WhenNoProducts()
    {
        // Arrange
        var loggerMock = A.Fake<ILogger<ProductsController>>();
        var mediatorMock = A.Fake<IMediator>();
        var mapperMock = A.Fake<IMapper>();
        
        var controller = new ProductsController(loggerMock, mediatorMock, mapperMock);

        // Set up MediatR to return a result with no products
        A.CallTo(() => mediatorMock.Send(A<ProductsQuery>._, CancellationToken.None))
                    .Returns(new ProductsFilterDto());

        // Act
        var result = await controller.GetProducts();

        // Assert
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task GetProducts_ReturnsOk_WithProducts()
    {
        // Arrange
        var loggerMock = A.Fake<ILogger<ProductsController>>();
        var mediatorMock = A.Fake<IMediator>();
        var mapperMock = TestStartup.CreateMapper();
        var controller = new ProductsController(loggerMock, mediatorMock, mapperMock);

        var products = new List<ProductResponse> {
            new ProductResponse {
                Description = "Test",
                Price = 12,
                Title = "Test",
                Sizes = new List<string>
                {
                    "Small",
                    "Medium",
                    "Large"
                }
            }
        };
        A.CallTo(() => mediatorMock.Send(A<ProductsQuery>._, CancellationToken.None))
                    .Returns(new ProductsFilterDto()
                    {
                        Products = products.Select(productDto => new ProductDto
                        {
                            Price = productDto.Price,
                            Description = productDto.Description,
                            Sizes = productDto.Sizes,
                            Title = productDto.Title
                        })
                    });

        // Act
        var result = await controller.GetProducts();

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = Assert.IsType<OkObjectResult>(result);
        okResult.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task GetProducts_WithFilter_ReturnsOk_WithFilteredProducts()
    {
        // Arrange
        var loggerMock = A.Fake<ILogger<ProductsController>>();
        var mediatorMock = A.Fake<IMediator>();
        var mapperMock = TestStartup.CreateMapper();

        var searchFilter = new ProductsQuery {Highlight = "string", MaxPrice = 13, MinPrice = 1, Size = "Small" };

        // Set up MediatR to return a result with filtered products
        var filteredProducts = new List<ProductResponse> { new ProductResponse {
           Description = "Test",
                Price = 12,
                Title = "Test",
                Sizes = new List<string>
                {
                    "Small",
                    "Medium",
                    "Large"
                }
        }};
        A.CallTo(() => mediatorMock.Send(A<ProductsQuery>._, CancellationToken.None))
                   .Returns(new ProductsFilterDto
                   {
                       Products = filteredProducts.Select(productDto => new ProductDto
                       {
                           Price = productDto.Price,
                           Description = productDto.Description,
                           Sizes = productDto.Sizes,
                           Title = productDto.Title
                       })
                   });
           
        var controller = new ProductsController(loggerMock, mediatorMock, mapperMock);

        // Act
        var result = await controller.GetProducts(new FilterProductsRequest { Size = searchFilter.Size, MinPrice = searchFilter.MinPrice, MaxPrice = searchFilter.MaxPrice, Highlight = searchFilter.Highlight});

        // Assert
        result.Should().BeOfType<OkObjectResult>();
        var okResult = Assert.IsType<OkObjectResult>(result);
        okResult.Value.Should().NotBeNull();
    }
}