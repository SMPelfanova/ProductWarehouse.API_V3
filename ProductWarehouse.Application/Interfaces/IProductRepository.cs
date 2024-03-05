using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions.Interfaces;

namespace ProductWarehouse.Application.Interfaces;

public interface IProductRepository : IRepository<Product>
{
	Task<Product> GetProductDetailsAsync(Guid id, CancellationToken cancellationToken);
	Task DeleteProductGroupAsync(Guid productId, Guid groupId, CancellationToken cancellationToken);
	Task<ProductSize> GetProductSizeAsync(Guid productId, Guid sizeId, CancellationToken cancellationToken);
	Task DeleteProductSizeAsync(Guid productId, Guid sizeId, CancellationToken cancellationToken);
	Task UpdateQuantityInStockAsync(ProductSize productSize, CancellationToken cancellationToken);
	Task<int> CheckQuantityInStockAsync(Guid productId, Guid sizeId, CancellationToken cancellationToken);
	Task UpdateProductIsDeletedAsync(Guid productId);
}