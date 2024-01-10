using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProductWarehouse.API.Controllers;
using ProductWarehouse.API.Models;
using ProductWarehouse.Application.Queries;
using ProductWarehouse.Application.Responses;
using Xunit;

public class ProductsControllerTests
{
    [Fact]
    public async Task GetProducts_ReturnsNotFound_WhenNoProducts()
    {
        // Arrange
        var loggerMock = new Mock<ILogger<ProductsController>>();
        var mediatorMock = new Mock<IMediator>();
        var controller = new ProductsController(loggerMock.Object, mediatorMock.Object);

        // Set up MediatR to return a result with no products
        mediatorMock.Setup(m => m.Send(It.IsAny<ProductsQuery>(), CancellationToken.None))
                    .ReturnsAsync(new ProductFilterResponse { Products = Enumerable.Empty<ProductResponse>() });

        // Act
        var result = await controller.GetProducts();

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    //[Fact]
    //public async Task GetProducts_ReturnsOk_WithProducts()
    //{
    //    // Arrange
    //    var loggerMock = new Mock<ILogger<ProductsController>>();
    //    var mediatorMock = new Mock<IMediator>();
    //    var controller = new ProductsController(loggerMock.Object, mediatorMock.Object);

    //    // Set up MediatR to return a result with some products
    //    var products = new List<ProductDto> { new ProductDto { /* set properties */ } };
    //    mediatorMock.Setup(m => m.Send(It.IsAny<ProductsQuery>(), CancellationToken.None))
    //                .ReturnsAsync(new ProductFilterResponse { Products = Enumerable.Empty<ProductResponse>() });

    //    // Act
    //    var result = await controller.GetProducts();

    //    // Assert
    //    Assert.IsType<OkObjectResult>(result);
    //    var okResult = Assert.IsType<OkObjectResult>(result);
    //    Assert.Equal(products, okResult.Value);
    //}

    //[Fact]
    //public async Task GetProducts_WithFilter_ReturnsOk_WithFilteredProducts()
    //{
    //    // Arrange
    //    var loggerMock = new Mock<ILogger<ProductsController>>();
    //    var mediatorMock = new Mock<IMediator>();
    //    var controller = new ProductsController(loggerMock.Object, mediatorMock.Object);

    //    var searchFilter = new ProductsQuery { /* set filter properties */ };

    //    // Set up MediatR to return a result with filtered products
    //    var filteredProducts = new List<ProductDto> { new ProductDto { /* set properties */ } };
    //    mediatorMock.Setup(m => m.Send(searchFilter, CancellationToken.None))
    //                .ReturnsAsync(new ProductFilterResponse { Products = Enumerable.Empty<ProductResponse>() });

    //    // Act
    //    var result = await controller.GetProducts(searchFilter);

    //    // Assert
    //    Assert.IsType<OkObjectResult>(result);
    //    var okResult = Assert.IsType<OkObjectResult>(result);
    //    Assert.Equal(filteredProducts, okResult.Value);
    //}
}