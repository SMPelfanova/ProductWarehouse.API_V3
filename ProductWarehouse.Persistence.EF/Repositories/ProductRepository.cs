using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;

namespace ProductWarehouse.Persistence.EF.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
	private readonly ApplicationDbContext _dbContext;

	public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<List<Product>> GetProductsAsync()
	{
		var products = await _dbContext.Products
			.Where(x => !x.IsDeleted)
			.Include(p => p.Brand)
			.Include(p => p.ProductGroups).ThenInclude(pg => pg.Group)
			.Include(p => p.ProductSizes).ThenInclude(pg => pg.Size)
			.ToListAsync();

		return products;
	}

	public Task<Product> GetProductDetailsAsync(Guid id)
	{
		return _dbContext.Products
			.Include(p => p.Brand)
			.Include(p => p.ProductGroups).ThenInclude(pg => pg.Group)
			.Include(p => p.ProductSizes).ThenInclude(pg => pg.Size)
			.SingleAsync(p => p.Id == id);
	}

	public void DeleteProductGroup(Guid productId, Guid groupId)
	{
		var entityToDelete = _dbContext.ProductGroups.Single(x => x.ProductId == productId && x.GroupId == groupId);

		if (entityToDelete != null)
		{
			_dbContext.ProductGroups.Remove(entityToDelete);
		}
	}

	public void UpdateProductSize(ProductSize productSize)
	{
		var entityToUpdate = _dbContext.ProductSizes.Single(x => x.ProductId == productSize.ProductId && x.SizeId == productSize.SizeId);
		if (entityToUpdate != null)
		{
			entityToUpdate.QuantityInStock = productSize.QuantityInStock;
			_dbContext.ProductSizes.Update(entityToUpdate);
		}
	}

	public Task<ProductSize> GetProductSizeAsync(Guid productId, Guid sizeId)
	{
		return _dbContext.ProductSizes
			.SingleAsync(x => x.ProductId == productId && x.SizeId == sizeId);
	}

	public async Task<int> CheckQuantityInStockAsync(Guid productId, Guid sizeId)
	{
		var productSize = await _dbContext.ProductSizes
							.SingleAsync(x => x.ProductId == productId && x.SizeId == sizeId);

		return productSize.QuantityInStock;
	}
}