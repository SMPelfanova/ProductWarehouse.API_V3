using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions.Interfaces;

namespace ProductWarehouse.Application.Interfaces;

public interface IBasketLineRepository : IRepository<BasketLine>
{
	Task<bool> GetByProductAndSizeAsync(Guid userId, Guid productId, Guid sizeId);
}