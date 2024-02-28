using Dapper;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.PostgreSQL.Constants.Dapper;
using Serilog;
using System.Data;
using static Dapper.SqlMapper;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class OrderStatusRepository : Repository<OrderStatus>, IOrderStatusRepository
{
	private readonly IDbConnection _dbConnection;
	private readonly ILogger _logger;
	public OrderStatusRepository(ApplicationDbContext dbContext, IDbConnection dbConnection, IDbTransaction dbTransaction, ILogger logger) : base(dbContext,  dbConnection, dbTransaction, logger)
	{
		_dbConnection = dbConnection;
		_logger = logger;
	}
	new public async Task<IReadOnlyList<OrderStatus>> GetAllAsync(CancellationToken cancellationToken)
	{
		IEnumerable<OrderStatus?> orderStatuses;

		try
		{
			orderStatuses = await _dbConnection.QueryAsync<OrderStatus>(QueryConstants.GetAllOrderStatusesQuery);
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while fetching all orders.", ex);
			throw new DatabaseException("An error occurred while fetching all orders.", ex);
		}

		if (orderStatuses is null || orderStatuses.Count() is 0)
		{
			_logger.Warning($"Order statuses not found.");
			throw new NotFoundException($"Order statuses not found.");
		}

		return orderStatuses.ToList().AsReadOnly();
	}

	new public async Task<OrderStatus> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		OrderStatus? orderStatus;
		try
		{
			orderStatus = await _dbConnection.QueryFirstOrDefaultAsync<OrderStatus>(QueryConstants.GetOrderStatusByIdQuery, new { Id = id });
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while fetching all orders.", ex);
			throw new DatabaseException("An error occurred while fetching all orders.", ex);
		}

		if (orderStatus is null)
		{
			_logger.Warning($"Order status not found.");
			throw new NotFoundException($"Order status not found.");
		}

		return orderStatus;
	}
}