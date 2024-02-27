using Dapper;
using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.PostgreSQL.Constants;
using Serilog;
using System.Data;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
	private readonly IDbConnection _dbConnection;
	private readonly ILogger _logger;
	private readonly IDbTransaction _dbTransaction;
	public ProductRepository(
		ApplicationDbContext dbContext, 
		IDbConnection  dbConnection,
		IDbTransaction dbTransaction, 
		ILogger logger) : base(dbContext,  dbConnection, dbTransaction, logger)
	{
		 _dbConnection =  dbConnection;
		_dbTransaction = dbTransaction;
		_logger = logger;
	}

	public async Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken)
	{
		try
		{
			var query = @"
                SELECT p.*, b.*, pg.*, s.*
                FROM ""Products"" p
                LEFT JOIN ""Brands"" b ON p.""BrandId"" = b.""Id""
                LEFT JOIN ""ProductGroups"" pg ON p.""Id"" = pg.""ProductId""
                LEFT JOIN ""Groups"" g ON pg.""GroupId"" = g.""Id""
                LEFT JOIN ""ProductSizes"" ps ON p.""Id"" = ps.""ProductId""
                LEFT JOIN ""Sizes"" s ON ps.""SizeId"" = s.""Id""
                WHERE p.""IsDeleted"" = FALSE";

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
				splitOn: "Id,Id,ProductId,Id,ProductId,Id,Id");

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
            FROM ""Products"" p
            LEFT JOIN ""Brands"" b ON p.""BrandId"" = b.""Id""
            LEFT JOIN ""ProductGroups"" pg ON p.""Id"" = pg.""ProductId""
            LEFT JOIN ""Groups"" g ON pg.""GroupId"" = g.""Id""
            LEFT JOIN ""ProductSizes"" ps ON p.""Id"" = ps.""ProductId""
            LEFT JOIN ""Sizes"" s ON ps.""SizeId"" = s.""Id""
            WHERE p.""Id"" = @Id AND p.""IsDeleted"" = FALSE";

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
				splitOn: "Id,Id,ProductId,Id,ProductId,Id,Id");

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
            FROM ""ProductSizes""
            WHERE ""ProductId"" = @ProductId AND ""SizeId"" = @SizeId";

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
            SELECT ""QuantityInStock""
            FROM ""ProductSizes""
            WHERE ""ProductId"" = @ProductId AND ""SizeId"" = @SizeId";

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
            DELETE FROM ""ProductGroups""
            WHERE ""ProductId"" = @ProductId AND ""GroupId"" = @GroupId";

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
            DELETE FROM ""ProductSizes""
            WHERE ""ProductId"" = @ProductId AND ""SizeId"" = @SizeId";

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
            UPDATE ""ProductSizes""
            SET ""QuantityInStock"" = @QuantityInStock
            WHERE ""ProductId"" = @ProductId AND ""SizeId"" = @SizeId";

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

	new public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
	{
		try
		{
			// Update the product
			var productUpdateQuery = @"
                    UPDATE ""Products"" 
                    SET 
                        ""BrandId"" = @BrandId,
                        ""Title"" = @Title,
                        ""Photo"" = @Photo,
                        ""Price"" = @Price,
                        ""Description"" = @Description,
                        ""IsDeleted"" = @IsDeleted
                    WHERE 
                        ""Id"" = @Id;
                ";
			await _dbConnection.ExecuteAsync(productUpdateQuery, product, _dbTransaction);

			// Delete existing related entries
			var deleteProductGroupsQuery = @"
                    DELETE FROM ""ProductGroups"" 
                    WHERE ""ProductId"" = @ProductId;
                ";
			await _dbConnection.ExecuteAsync(deleteProductGroupsQuery, new { ProductId = product.Id }, _dbTransaction);

			var deleteProductSizesQuery = @"
                    DELETE FROM ""ProductSizes"" 
                    WHERE ""ProductId"" = @ProductId;
                ";
			await _dbConnection.ExecuteAsync(deleteProductSizesQuery, new { ProductId = product.Id }, _dbTransaction);

			// Insert new related entries
			foreach (var group in product.ProductGroups)
			{
				var productGroupInsertQuery = @"
                        INSERT INTO ""ProductGroups"" (""ProductId"", ""GroupId"")
                        VALUES (@ProductId, @GroupId);
                    ";
				await _dbConnection.ExecuteAsync(productGroupInsertQuery, new { ProductId = product.Id, GroupId = group.GroupId }, _dbTransaction);
			}

			foreach (var size in product.ProductSizes)
			{
				var productSizeInsertQuery = @"
                        INSERT INTO ""ProductSizes"" (""ProductId"", ""SizeId"", ""QuantityInStock"")
                        VALUES (@ProductId, @SizeId, @QuantityInStock);
                    ";
				await _dbConnection.ExecuteAsync(productSizeInsertQuery, new { ProductId = product.Id, SizeId = size.SizeId, QuantityInStock = size.QuantityInStock }, _dbTransaction);
			}

		}
		catch
		{
			// Rollback the transaction if an error occurs
			_dbTransaction.Rollback();
			throw; // Re-throw the exception to propagate it to the caller
		}
	}

	new public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
	{
		var query = @"
                INSERT INTO ""Products"" (""BrandId"", ""Title"", ""Photo"", ""Price"", ""Description"", ""IsDeleted"") 
                VALUES (@BrandId, @Title, @Photo, @Price, @Description, @IsDeleted)
				RETURNING ""Id"";";

		var id = await _dbConnection.ExecuteScalarAsync<Guid>(query, product, _dbTransaction);
		product.Id = id;
		foreach (var group in product.ProductGroups)
		{

			var productGroupQuery = @"

					INSERT INTO ""ProductGroups"" (""ProductId"", ""GroupId"")
                    VALUES (@ProductId, @GroupId)
                     ON CONFLICT (""ProductId"", ""GroupId"") DO NOTHING;";

			await _dbConnection.ExecuteAsync(productGroupQuery, new { ProductId = product.Id, GroupId = group.GroupId }, _dbTransaction);
		}

		foreach (var size in product.ProductSizes)
		{
			var productSizeQuery = @"
                    INSERT INTO ""ProductSizes"" (""ProductId"", ""SizeId"", ""QuantityInStock"")
                    VALUES (@ProductId, @SizeId, @QuantityInStock)
                    ON CONFLICT (""ProductId"", ""SizeId"") DO UPDATE SET ""QuantityInStock"" = @QuantityInStock;";

			await _dbConnection.ExecuteAsync(productSizeQuery, new { ProductId = product.Id, SizeId = size.SizeId, QuantityInStock = size.QuantityInStock }, _dbTransaction);
		}

		return product;
	}

}