namespace ProductWarehouse.UnitTests.API.Controllers;

using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductWarehouse.API.Controllers;
using ProductWarehouse.API.Models.Requests.Base;
using ProductWarehouse.API.Models.Responses;
using ProductWarehouse.Application.Features.Queries.GetProducts;
using ProductWarehouse.Application.Models.Product;
using ProductWarehouse.UnitTests;
using System.Threading;
using Xunit;

public class ProductsControllerTests
{
	
	[Fact]
	public async Task GetProducts_ReturnsOk_WithProducts()
	{
		// Arrange
		var fixture = new Fixture();
		fixture.Customize(new AutoMoqCustomization());
		var loggerMock = A.Fake<ILogger<ProductsController>>();
		var mediatorMock = A.Fake<IMediator>();
		var cancellationTokenSource = new CancellationTokenSource();
		cancellationTokenSource.Cancel(); 
		var cancellationToken = cancellationTokenSource.Token;
		var mapperMock = TestStartup.CreateMapper();
		var controller = new ProductsController();

		var products = fixture.CreateMany<ProductDto>(2);

		A.CallTo(() => mediatorMock.Send(A<GetAllProductsQuery>._, CancellationToken.None))
					.Returns(new ProductsFilterDto()
					{
						Products = products.ToList()
					});

		// Act
		var result = await controller.GetProducts(new BaseEmptyRequest(), mediatorMock, mapperMock, cancellationToken);

		// Assert
		result.Should().BeOfType<OkObjectResult>();
		var okResult = Assert.IsType<OkObjectResult>(result);
		okResult.Value.Should().NotBeNull();
	}

	[Fact]
	public async Task GetProducts_WithFilter_ReturnsOk_WithFilteredProducts()
	{
		// Arrange
		var fixture = new Fixture();
		fixture.Customize(new AutoMoqCustomization());
		var loggerMock = A.Fake<ILogger<ProductsController>>();
		var mediatorMock = A.Fake<IMediator>();
		var mapperMock = TestStartup.CreateMapper();
		var cancellationTokenSource = new CancellationTokenSource();
		cancellationTokenSource.Cancel();
		var cancellationToken = cancellationTokenSource.Token;

		var searchFilter = new GetAllProductsQuery { Highlight = "string", MaxPrice = 13, MinPrice = 1, Size = "Small" };
		var filteredProducts = fixture.CreateMany<ProductResponse>(2);

		var products = fixture.CreateMany<ProductDto>(2);
		A.CallTo(() => mediatorMock.Send(A<GetAllProductsQuery>._, CancellationToken.None))
				   .Returns(new ProductsFilterDto
				   {
					   Products = products.ToList()
				   });

		var controller = new ProductsController();

		// Act
		var result = await controller.GetProducts(new BaseEmptyRequest(), mediatorMock, mapperMock, cancellationToken);

		// Assert
		result.Should().BeOfType<OkObjectResult>();
		var okResult = Assert.IsType<OkObjectResult>(result);
		okResult.Value.Should().NotBeNull();
	}
}