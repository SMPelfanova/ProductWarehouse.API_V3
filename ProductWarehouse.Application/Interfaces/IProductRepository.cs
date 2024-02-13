using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions.Interfaces;

namespace ProductWarehouse.Application.Interfaces;

public interface IProductRepository : IRepository<Product>
{
	Task<List<Product>> GetProductsAsync();

	Task<Product> GetProductDetailsAsync(Guid id);

	void DeleteProductGroup(Guid productId, Guid groupId);

	Task<ProductSize> GetProductSizeAsync(Guid productId, Guid sizeId);

	void UpdateProductSize(ProductSize productSize);

	Task<int> CheckQuantityInStockAsync(Guid productId, Guid sizeId);
}