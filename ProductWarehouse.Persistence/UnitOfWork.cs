using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Persistence.PostgreSQL;
using System.Data;

namespace ProductWarehouse.Persistence;

internal class UnitOfWork : IUnitOfWork
{
	private readonly ApplicationDbContext _dbContext;
	IDbTransaction _dbTransaction;
	public IProductRepository Products { get; }

	public ISizeRepository Sizes { get; }

	public IOrderRepository Orders { get; }

	public IBrandRepository Brands { get; }

	public IOrderStatusRepository OrdersStatuses { get; }

	public IGroupRepository Group { get; }

	public IBasketRepository Basket { get; }

	public IBasketLineRepository BasketLines { get; }

	public IUserRepository User { get; }

	public IProductSizeRepository ProductSizes { get; }

	public UnitOfWork(ApplicationDbContext dbContext,
						IDbTransaction dbTransaction,
						IOrderStatusRepository orderStatusRepository,
						IGroupRepository groupRepository,
						IProductRepository productRepository,
						IProductSizeRepository productSizeRepository,
						ISizeRepository sizesRepository,
						IOrderRepository ordersRepository,
						IBrandRepository brandsRepository,
						IUserRepository userRepository,
						IBasketRepository basketRepository,
						IBasketLineRepository basketLineRepository
						)
	{
		_dbContext = dbContext;
		_dbTransaction = dbTransaction;
		OrdersStatuses = orderStatusRepository;
		Group = groupRepository;
		Products = productRepository;
		Sizes = sizesRepository;
		Orders = ordersRepository;
		Brands = brandsRepository;
		Basket = basketRepository;
		BasketLines = basketLineRepository;
		User = userRepository;
		ProductSizes = productSizeRepository;
	}
	public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
	{
	_dbTransaction.Commit();	
		return await _dbContext.SaveChangesAsync(cancellationToken);
	}

	public void Rollback()
	{
		_dbTransaction.Rollback();
		_dbContext.Database.RollbackTransaction();
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			_dbTransaction.Connection?.Close();
			_dbTransaction.Connection?.Dispose();
			_dbTransaction.Dispose();
			_dbContext.Dispose();
		}
	}
}