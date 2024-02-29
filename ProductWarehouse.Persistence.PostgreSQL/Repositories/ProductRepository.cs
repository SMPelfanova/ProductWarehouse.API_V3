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
			await _dbConnection.ExecuteAsync(CommandConstants.UpdatePproduct, product, _dbTransaction);

			await _dbConnection.ExecuteAsync(CommandConstants.DeleteProductGroups, new { ProductId = product.Id }, _dbTransaction);

			await _dbConnection.ExecuteAsync(CommandConstants.DeleteProductSizes, new { ProductId = product.Id }, _dbTransaction);

			foreach (var group in product.ProductGroups)
			{
				await _dbConnection.ExecuteAsync(CommandConstants.InsertProductGroup, new
				{
					ProductId = product.Id,
					GroupId = group.GroupId
				}, _dbTransaction);
			}

			foreach (var size in product.ProductSizes)
			{
				await _dbConnection.ExecuteAsync(CommandConstants.InsertProductSize, new
				{
					ProductId = product.Id,
					SizeId = size.SizeId,
					QuantityInStock = size.QuantityInStock
				}, _dbTransaction);
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
			var id = await _dbConnection.ExecuteScalarAsync<Guid>(CommandConstants.InsertProduct, product, _dbTransaction);
			product.Id = id;
			foreach (var group in product.ProductGroups)
			{
				await _dbConnection.ExecuteAsync(CommandConstants.InsertProductGroup, new { ProductId = product.Id, GroupId = group.GroupId }, _dbTransaction);
			}

			foreach (var size in product.ProductSizes)
			{
				await _dbConnection.ExecuteAsync(CommandConstants.InsertProductSize, new { ProductId = product.Id, SizeId = size.SizeId, QuantityInStock = size.QuantityInStock }, _dbTransaction);
			}

			var groups = await _dbConnection.QueryAsync<ProductGroups, Group, ProductGroups>(
				QueryConstants.GetProductGroups,
				(productGroup, group) =>
				{
					productGroup.Group = group;
					return productGroup;
				},
				new { ProductId = product.Id },
				_dbTransaction,
				splitOn: $"{nameof(Baskets.Id)}");

			var sizes = await _dbConnection.QueryAsync<ProductSize, Size, ProductSize>(QueryConstants.GetProductSizes,
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
			_logger.Warning(MessageConstants.NotFoundErrorMessage(nameof(Product)));
			throw new NotFoundException(MessageConstants.NotFoundErrorMessage(nameof(Product)));
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
				CommandConstants.DeleteProductGroup,
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
				CommandConstants.DeleteProductSize,
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
				CommandConstants.UpdateQuantityInStock,
				new { QuantityInStock = productSize.QuantityInStock, ProductId = productSize.ProductId, SizeId = productSize.SizeId });
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(ProductSize)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(ProductSize)), ex);
		}
	}
}