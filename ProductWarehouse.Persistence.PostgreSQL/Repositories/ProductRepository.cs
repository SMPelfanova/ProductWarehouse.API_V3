using Dapper;
using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.PostgreSQL.Constants;
using ProductWarehouse.Persistence.PostgreSQL.Constants.Dapper;
using Serilog;
using System.Data;
using static Dapper.SqlMapper;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
	private readonly IDbConnection _dbConnection;
	private readonly ILogger _logger;
	private readonly IDbTransaction _dbTransaction;
	public ProductRepository(
		ApplicationDbContext dbContext,
		IDbConnection dbConnection,
		IDbTransaction dbTransaction,
		ILogger logger) : base(dbContext, dbConnection, dbTransaction, logger)
	{
		_dbConnection = dbConnection;
		_dbTransaction = dbTransaction;
		_logger = logger;
	}

	new public async Task<IReadOnlyList<Product>> GetAllAsync(CancellationToken cancellationToken)
	{
		try
		{
			var productsDictionary = new Dictionary<Guid, Product>();
			var products = await _dbConnection.QueryAsync<Product, Brand, ProductGroups, ProductSize, Size, Group, Product>(
				QueryConstants.GetAllProductsQuery,
				(product, brand, productGroup, productSize, size, group) =>
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
				splitOn: $"{nameof(Brand.Id)},{nameof(ProductGroups.ProductId)},{nameof(ProductSize.ProductId)},{nameof(Size.Id)},{nameof(Group.Id)}");

			return products.ToList().AsReadOnly();
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Product)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Product)), ex);
		}
	}

	new public async Task UpdateAsync(Product product, CancellationToken cancellationToken = default)
	{
		try
		{
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
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Product)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Product)), ex);
		}
	}

	new public async Task<Product> AddAsync(Product product, CancellationToken cancellationToken = default)
	{
		try
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

			// Fetch newly added groups associated with the product
			var groupsQuery = @"
					SELECT 
						pg.*,
						g.*
					FROM 
						""ProductGroups"" pg
					INNER JOIN 
						""Groups"" g ON pg.""GroupId"" = g.""Id""
					WHERE 
						pg.""ProductId"" = @ProductId;";

			var groups = await _dbConnection.QueryAsync<ProductGroups, Group, ProductGroups>(
				groupsQuery,
				(productGroup, group) =>
				{
					productGroup.Group = group;
					return productGroup;
				},
				new { ProductId = product.Id },
				_dbTransaction,
				splitOn: $"{nameof(Baskets.Id)}");

			// Fetch newly added sizes associated with the product
			var sizesQuery = @"
					SELECT 
						ps.*,
						s.*
					FROM 
						""ProductSizes"" ps
					INNER JOIN 
						""Sizes"" s ON ps.""SizeId"" = s.""Id""
					WHERE 
						ps.""ProductId"" = @ProductId;";

			var sizes = await _dbConnection.QueryAsync<ProductSize, Size, ProductSize>(
				sizesQuery,
				(productSize, size) =>
				{
					productSize.Size = size;
					return productSize;
				},
				new { ProductId = product.Id },
				_dbTransaction,
				splitOn: $"{nameof(Baskets.Id)}");

			product.ProductGroups = groups.ToList();
			product.ProductSizes = sizes.ToList();
			return product;
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Product)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Product)), ex);
		}
	}

	public async Task<Product> GetProductDetailsAsync(Guid id, CancellationToken cancellationToken)
	{
		Product? product;
		try
		{
			var productsDictionary = new Dictionary<Guid, Product>();
			product = await _dbConnection.QueryFirstOrDefaultAsync<Product>(QueryConstants.GetProductDetailsQuery, new { Id = id });

			var products = await _dbConnection.QueryAsync<Product, Brand, ProductGroups, Group, ProductSize, Size, Product>(
				QueryConstants.GetProductDetailsQuery,
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

					if (productGroup != null)
					{
						productGroup.Product = productEntry;
						productGroup.Group = group;
						productEntry.ProductGroups.Add(productGroup);
					}

					if (productSize != null)
					{
						productSize.Product = productEntry;
						productSize.Size = size;
						productSize.ProductId = product.Id;
						productEntry.ProductSizes.Add(productSize);
					}

					return productEntry;
				},
				new { Id = id },
				splitOn: $"{nameof(Brand.Id)},{nameof(ProductGroups.GroupId)},{nameof(Group.Id)},{nameof(ProductSize.SizeId)},{nameof(Size.Id)}");
			product = products.FirstOrDefault();
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Product)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Product)), ex);
		}

		if (product is null)
		{
			_logger.Warning($"Product not found.");
			throw new NotFoundException($"Product not found.");
		}

		return product;
	}

	public async Task<ProductSize> GetProductSizeAsync(Guid productId, Guid sizeId, CancellationToken cancellationToken)
	{
		try
		{
			return await _dbConnection.QueryFirstOrDefaultAsync<ProductSize>(
				QueryConstants.GetProductSizeQuery,
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
			return await _dbConnection.ExecuteScalarAsync<int>(
				QueryConstants.CheckQuantityInStockQuery,
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
			await _dbConnection.ExecuteAsync(
				CommandConstants.DeleteProductGroupCommand,
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
			await _dbConnection.ExecuteAsync(
				CommandConstants.DeleteProductSizeCommand,
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
			await _dbConnection.ExecuteAsync(
				CommandConstants.UpdateQuantityInStockCommand,
				new { QuantityInStock = productSize.QuantityInStock, ProductId = productSize.ProductId, SizeId = productSize.SizeId });
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(ProductSize)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(ProductSize)), ex);
		}
	}
}