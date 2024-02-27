using Dapper;
using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.PostgreSQL.Constants;
using Serilog;
using System.Data;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
	private readonly ApplicationDbContext _dbContext;
	private readonly IDbConnection _dbConnection;
	private readonly ILogger _logger;

	public ProductRepository(
		ApplicationDbContext dbContext, 
		IDbConnection  dbConnection,
		IDbTransaction dbTransaction, 
		ILogger logger) : base(dbContext,  dbConnection, dbTransaction, logger)
	{
		_dbContext = dbContext;
		 _dbConnection =  dbConnection;
		_logger = logger;
	}

	public async Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken)
	{
		try
		{
			var query = @"
                    SELECT p.*, b.*, pg.*, s.*
                    FROM Products p
                    LEFT JOIN Brands b ON p.BrandId = b.Id
                    LEFT JOIN ProductGroups pg ON p.Id = pg.ProductId
                    LEFT JOIN Groups g ON pg.GroupId = g.Id
                    LEFT JOIN ProductSizes ps ON p.Id = ps.ProductId
                    LEFT JOIN Sizes s ON ps.SizeId = s.Id
                    WHERE p.IsDeleted = FALSE";

			var productsDictionary = new Dictionary<Guid, Product>();
			var products = await _dbConnection.QueryAsync<Product, Brand, ProductGroups, Group, ProductSize, Size, Product>(
				query,
				(product, brand, productGroup, group, productSize, size) =>
				{
					if (!productsDictionary.TryGetValue(product.Id, out var productEntry))
					{
						productEntry = product;
						productEntry.Brand = brand;
						productEntry.ProductGroups = new List<ProductGroups>();
						productEntry.ProductSizes = new List<ProductSize>();
						productsDictionary.Add(productEntry.Id, productEntry);
					}

					if (productGroup != null && !productEntry.ProductGroups.Any(pg => pg.GroupId == productGroup.GroupId))
					{
						productGroup.Group = group;
						productEntry.ProductGroups.Add(productGroup);
					}

					if (productSize != null && !productEntry.ProductSizes.Any(ps => ps.SizeId == productSize.SizeId))
					{
						productSize.Size = size;
						productEntry.ProductSizes.Add(productSize);
					}

					return productEntry;
				},
				splitOn: "Id,Id,Id,Id,Id");

			return products.AsList();
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Product)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Product)), ex);
		}
	}

	public async Task<Product> GetProductDetailsAsync(Guid id, CancellationToken cancellationToken)
	{
		try
		{
			var query = @"
            SELECT p.*, b.*, pg.*, s.*
            FROM Products p
            LEFT JOIN Brands b ON p.BrandId = b.Id
            LEFT JOIN ProductGroups pg ON p.Id = pg.ProductId
            LEFT JOIN Groups g ON pg.GroupId = g.Id
            LEFT JOIN ProductSizes ps ON p.Id = ps.ProductId
            LEFT JOIN Sizes s ON ps.SizeId = s.Id
            WHERE p.Id = @Id AND p.IsDeleted = FALSE";

			var productsDictionary = new Dictionary<Guid, Product>();
			var products = await _dbConnection.QueryAsync<Product, Brand, ProductGroups, Group, ProductSize, Size, Product>(
				query,
				(product, brand, productGroup, group, productSize, size) =>
				{
					if (!productsDictionary.TryGetValue(product.Id, out var productEntry))
					{
						productEntry = product;
						productEntry.Brand = brand;
						productEntry.ProductGroups = new List<ProductGroups>();
						productEntry.ProductSizes = new List<ProductSize>();
						productsDictionary.Add(productEntry.Id, productEntry);
					}

					if (productGroup != null && !productEntry.ProductGroups.Any(pg => pg.GroupId == productGroup.GroupId))
					{
						productGroup.Group = group;
						productEntry.ProductGroups.Add(productGroup);
					}

					if (productSize != null && !productEntry.ProductSizes.Any(ps => ps.SizeId == productSize.SizeId))
					{
						productSize.Size = size;
						productEntry.ProductSizes.Add(productSize);
					}

					return productEntry;
				},
				new { Id = id },
				splitOn: "Id,Id,Id,Id,Id");

			return products.FirstOrDefault();
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Product)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Product)), ex);
		}
	}

	public async Task<ProductSize> GetProductSizeAsync(Guid productId, Guid sizeId, CancellationToken cancellationToken)
	{
		try
		{
			var query = @"
            SELECT *
            FROM ProductSizes
            WHERE ProductId = @ProductId AND SizeId = @SizeId";

			return await _dbConnection.QueryFirstOrDefaultAsync<ProductSize>(
				query,
				new { ProductId = productId, SizeId = sizeId });
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(ProductSize)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(ProductSize)), ex);
		}
	}

	public async Task<int> CheckQuantityInStockAsync(Guid productId, Guid sizeId, CancellationToken cancellationToken)
	{
		try
		{
			var query = @"
            SELECT QuantityInStock
            FROM ProductSizes
            WHERE ProductId = @ProductId AND SizeId = @SizeId";

			return await _dbConnection.ExecuteScalarAsync<int>(
				query,
				new { ProductId = productId, SizeId = sizeId });
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(ProductSize)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(ProductSize)), ex);
		}
	}

	public async Task DeleteProductGroupAsync(Guid productId, Guid groupId, CancellationToken cancellationToken)
	{
		try
		{
			var query = @"
            DELETE FROM ProductGroups
            WHERE ProductId = @ProductId AND GroupId = @GroupId";

			await _dbConnection.ExecuteAsync(
				query,
				new { ProductId = productId, GroupId = groupId });
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(ProductGroups)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(ProductGroups)), ex);
		}
	}

	public async Task DeleteProductSizeAsync(Guid productId, Guid sizeId, CancellationToken cancellationToken)
	{
		try
		{
			var query = @"
            DELETE FROM ProductSizes
            WHERE ProductId = @ProductId AND SizeId = @SizeId";

			await _dbConnection.ExecuteAsync(
				query,
				new { ProductId = productId, SizeId = sizeId });
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(ProductSize)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(ProductSize)), ex);
		}
	}

	public async Task UpdateQuantityInStockAsync(ProductSize productSize, CancellationToken cancellationToken)
	{
		try
		{
			var query = @"
            UPDATE ProductSizes
            SET QuantityInStock = @QuantityInStock
            WHERE ProductId = @ProductId AND SizeId = @SizeId";

			await _dbConnection.ExecuteAsync(
				query,
				new { QuantityInStock = productSize.QuantityInStock, ProductId = productSize.ProductId, SizeId = productSize.SizeId });
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(ProductSize)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(ProductSize)), ex);
		}
	}

}