using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions.Interfaces;

namespace ProductWarehouse.Application.Interfaces;

public interface IProductRepository : IRepository<Product>
{
	Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken = default);
	Task<Product> GetProductDetailsAsync(Guid id, CancellationToken cancellationToken = default);
	Task DeleteProductGroupAsync(Guid productId, Guid groupId, CancellationToken cancellationToken = default);
	Task<ProductSize> GetProductSizeAsync(Guid productId, Guid sizeId, CancellationToken cancellationToken = default);
	Task DeleteProductSizeAsync(Guid productId, Guid sizeId, CancellationToken cancellationToken = default);
	Task UpdateQuantityInStockAsync(ProductSize productSize, CancellationToken cancellationToken = default);
	Task<int> CheckQuantityInStockAsync(Guid productId, Guid sizeId, CancellationToken cancellationToken = default);
}