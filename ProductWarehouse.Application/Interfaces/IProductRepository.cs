using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions.Interfaces;

namespace ProductWarehouse.Application.Interfaces;

public interface IProductRepository: IRepository<Product>
{
    Task<Product> GetProductDetails(Guid id);
    void DeleteProductGroups(Guid productId, Guid groupId);
    void DeleteProductSizes(Guid productId, Guid sizeId);
    void UpdateProductSize(ProductSize productSize);
    Task<ProductSize> GetProductSize(Guid productId, Guid sizeId);
}
