using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions.Interfaces;

namespace ProductWarehouse.Application.Interfaces;

public interface IBasketRepository : IRepository<Basket>
{
	Task<Basket> GetBasketByUserIdAsync(Guid userId);

	Task DeleteBasketLinesAsync(Guid userId);
}