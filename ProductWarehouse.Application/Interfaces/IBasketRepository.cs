using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions.Interfaces;

namespace ProductWarehouse.Application.Interfaces;

public interface IBasketRepository : IRepository<Basket>
{
	Basket GetBasketByUserId(Guid userId);

	void DeleteBasketLines(Guid userId);
}