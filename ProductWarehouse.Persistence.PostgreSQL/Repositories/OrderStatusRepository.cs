using Dapper;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.PostgreSQL.Constants.Dapper.Queries;
using Serilog;
using System.Data;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class OrderStatusRepository : Repository<OrderStatus>, IOrderStatusRepository
{
	private readonly ApplicationDbContext _dbContext;
	private readonly IDbConnection _dbConnection;
	private readonly ILogger _logger;
	public OrderStatusRepository(ApplicationDbContext dbContext, IDbConnection dbConnection, IDbTransaction dbTransaction, ILogger logger) : base(dbContext,  dbConnection, dbTransaction, logger)
	{
		_dbContext = dbContext;
		_dbConnection = dbConnection;
		_logger = logger;
	}
	new public async Task<IReadOnlyList<OrderStatus>> GetAllAsync(CancellationToken cancellationToken)
	{
		try
		{
			var entities = await _dbConnection.QueryAsync<OrderStatus>(QueryConstants.GetAllOrderStatusesQuery);
			return entities.ToList().AsReadOnly();
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while fetching all orders.", ex);
			throw new DatabaseException("An error occurred while fetching all orders.", ex);
		}
	}

	new public async Task<OrderStatus> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		try
		{
			var orderStatus = await _dbConnection.QueryFirstOrDefaultAsync<OrderStatus>(QueryConstants.GetOrderStatusByIdQuery, new { Id = id });
			return orderStatus;
		}
		catch (Exception ex)
		{
			_logger.Error("An error occurred while fetching all orders.", ex);
			throw new DatabaseException("An error occurred while fetching all orders.", ex);
		}
	}
}