using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetProductsAsync();
}
