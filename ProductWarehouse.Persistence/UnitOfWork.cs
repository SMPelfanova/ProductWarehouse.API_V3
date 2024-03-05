using Microsoft.EntityFrameworkCore.Storage;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Persistence.PostgreSQL;
using System.Data;

namespace ProductWarehouse.Persistence;

internal class UnitOfWork : IUnitOfWork
{
	private readonly ApplicationDbContext _dbContext;
	private IDbTransaction _dbTransaction;
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

	public IDbTransaction BeginTransaction()
	{
		if (_dbTransaction == null)
		{
			_dbTransaction = _dbContext.Database.BeginTransaction().GetDbTransaction();
		}

		return _dbTransaction;
	}

	public void CommitTransaction()
	{
		_dbTransaction?.Commit();
	}

	public void RollbackTransaction()
	{
		_dbTransaction?.Rollback();
	}


	public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
	{
		return await _dbContext.SaveChangesAsync(cancellationToken);
	}

	public async Task Rollback()
	{
		await _dbContext.Database.RollbackTransactionAsync();
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
			if (_dbTransaction != null)
			{
				_dbTransaction.Connection?.Close();
				_dbTransaction.Connection?.Dispose();
				_dbTransaction.Dispose();
			}
			_dbContext.Dispose();
		}
	}
}