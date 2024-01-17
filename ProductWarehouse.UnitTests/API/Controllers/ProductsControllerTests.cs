namespace ProductWarehouse.UnitTests.API.Controllers;

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
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
        var loggerMock = new Mock<ILogger<ProductsController>>();
        var mediatorMock = new Mock<IMediator>();
        var mapperMock = new Mock<IMapper>();
        
        var controller = new ProductsController(loggerMock.Object, mediatorMock.Object, mapperMock.Object);

        // Set up MediatR to return a result with no products
        mediatorMock.Setup(m => m.Send(It.IsAny<ProductsQuery>(), CancellationToken.None))
                    .ReturnsAsync(new ProductsFilterDto());

        // Act
        var result = await controller.GetProducts();

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetProducts_ReturnsOk_WithProducts()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<ProductsController>>();
        var mediatorMock = new Mock<IMediator>();
        var mapperMock = TestStartup.CreateMapper();
        var controller = new ProductsController(loggerMock.Object, mediatorMock.Object, mapperMock);

        // Set up MediatR to return a result with some products
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
        mediatorMock.Setup(m => m.Send(It.IsAny<ProductsQuery>(), CancellationToken.None))
                    .ReturnsAsync(new ProductsFilterDto()
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
        Assert.IsType<OkObjectResult>(result);
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public async Task GetProducts_WithFilter_ReturnsOk_WithFilteredProducts()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<ProductsController>>();
        var mediatorMock = new Mock<IMediator>();
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
        mediatorMock.Setup(m => m.Send(It.IsAny<ProductsQuery>(), CancellationToken.None))
                   .ReturnsAsync(new ProductsFilterDto
                   {
                       Products = filteredProducts.Select(productDto => new ProductDto
                       {
                           Price = productDto.Price,
                           Description = productDto.Description,
                           Sizes = productDto.Sizes,
                           Title = productDto.Title
                       })
                   });
           
        var controller = new ProductsController(loggerMock.Object, mediatorMock.Object, mapperMock);

        // Act
        var result = await controller.GetProducts(new FilterProductsRequest { Size = searchFilter.Size, MinPrice = searchFilter.MinPrice, MaxPrice = searchFilter.MaxPrice, Highlight = searchFilter.Highlight});

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }
}