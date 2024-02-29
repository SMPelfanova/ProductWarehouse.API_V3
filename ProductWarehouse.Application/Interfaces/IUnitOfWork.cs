using System.Data;

namespace ProductWarehouse.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
	IProductRepository Products { get; }
	IProductSizeRepository ProductSizes { get; }
	ISizeRepository Sizes { get; }
	IOrderStatusRepository OrdersStatuses { get; }
	IGroupRepository Group { get; }
	IOrderRepository Orders { get; }
	IBrandRepository Brands { get; }
	IBasketRepository Basket { get; }
	IBasketLineRepository BasketLines { get; }
	IUserRepository User { get; }

	IDbTransaction BeginTransaction();
	void CommitTransaction();
	void RollbackTransaction();
	Task<int> SaveChangesAsync(CancellationToken cancellationToken);

	void Rollback();
}