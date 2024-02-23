using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.EF.Constants;
using Serilog;

namespace ProductWarehouse.Persistence.EF.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
	private readonly ApplicationDbContext _dbContext;
	private readonly ILogger _logger;

	public ProductRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
	{
		_dbContext = dbContext;
		_logger = logger;
	}

	public async Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken)
	{
		try
		{
			var products = await _dbContext.Products
				.Where(x => !x.IsDeleted)
				.Include(p => p.Brand)
				.Include(p => p.ProductGroups).ThenInclude(pg => pg.Group)
				.Include(p => p.ProductSizes).ThenInclude(pg => pg.Size)
				.ToListAsync(cancellationToken);

			return products;
		}
		catch (InvalidOperationException ex)
		{
			_logger.Warning(MessageConstants.NotFoundErrorMessage(nameof(Product)), ex);
			throw new NotFoundException(MessageConstants.NotFoundErrorMessage(nameof(Product)), ex);
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
			return await _dbContext.Products
				.AsNoTracking()
				.Include(p => p.Brand)
				.Include(p => p.ProductGroups).ThenInclude(pg => pg.Group)
				.Include(p => p.ProductSizes).ThenInclude(pg => pg.Size)
				.SingleAsync(p => p.Id == id && !p.IsDeleted, cancellationToken);
		}
		catch (InvalidOperationException ex)
		{
			_logger.Warning(MessageConstants.NotFoundErrorMessage(nameof(Product), id), ex);
			throw new NotFoundException(MessageConstants.NotFoundErrorMessage(nameof(Product), id), ex);
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
			return await _dbContext.ProductSizes
						.SingleAsync(x => x.ProductId == productId && x.SizeId == sizeId, cancellationToken);
		}
		catch (InvalidOperationException ex)
		{
			_logger.Warning(MessageConstants.ProductSizeNotFoundErrorMessage(productId, sizeId), ex);
			throw new NotFoundException(MessageConstants.ProductSizeNotFoundErrorMessage(productId, sizeId), ex);
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
			var productSize = await _dbContext.ProductSizes
						.SingleAsync(x => x.ProductId == productId && x.SizeId == sizeId, cancellationToken);

			return productSize.QuantityInStock;
		}
		catch (InvalidOperationException ex)
		{
			_logger.Warning(MessageConstants.ProductSizeNotFoundErrorMessage(productId, sizeId), ex);
			throw new NotFoundException(MessageConstants.ProductSizeNotFoundErrorMessage(productId, sizeId), ex);
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
			var entityToDelete = await _dbContext.ProductGroups.SingleAsync(x => x.ProductId == productId && x.GroupId == groupId, cancellationToken);
			_dbContext.ProductGroups.Remove(entityToDelete);
		}
		catch (InvalidOperationException ex)
		{
			_logger.Warning(MessageConstants.ProductGroupNotFoundErrorMessage(productId, groupId), ex);
			throw new NotFoundException(MessageConstants.ProductGroupNotFoundErrorMessage(productId, groupId), ex);
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
			var entityToDelete = await _dbContext.ProductSizes.SingleAsync(x => x.ProductId == productId && x.SizeId == sizeId, cancellationToken);
			_dbContext.ProductSizes.Remove(entityToDelete);
		}
		catch (InvalidOperationException ex)
		{
			_logger.Warning(MessageConstants.ProductSizeNotFoundErrorMessage(productId, sizeId), ex);
			throw new NotFoundException(MessageConstants.ProductSizeNotFoundErrorMessage(productId, sizeId), ex);
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
			var entityToUpdate = await _dbContext.ProductSizes.SingleAsync(x => x.ProductId == productSize.ProductId && x.SizeId == productSize.SizeId, cancellationToken);
			entityToUpdate.QuantityInStock = productSize.QuantityInStock;
			_dbContext.ProductSizes.Update(entityToUpdate);
		}
		catch (InvalidOperationException ex)
		{
			_logger.Warning(MessageConstants.ProductSizeNotFoundErrorMessage(productSize.ProductId, productSize.SizeId), ex);
			throw new NotFoundException(MessageConstants.ProductSizeNotFoundErrorMessage(productSize.ProductId, productSize.SizeId), ex);
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(ProductSize)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(ProductSize)), ex);
		}
	}
}