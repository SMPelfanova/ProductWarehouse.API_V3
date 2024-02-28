using Dapper;
using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.PostgreSQL.Constants;
using Serilog;
using System.Data;
using System.Data.Common;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
	private readonly ApplicationDbContext _dbContext;
	private readonly IDbConnection _dbConnection;
	private readonly ILogger _logger;

	public OrderRepository(ApplicationDbContext dbContext, IDbConnection dbConnection, IDbTransaction dbTransaction, ILogger logger) : base(dbContext, dbConnection, dbTransaction, logger)
	{
		_dbContext = dbContext;
		_dbConnection = dbConnection;
		_logger = logger;
	}

	public async Task<Order> GetOrderDetailsAsync(Guid id, CancellationToken cancellationToken)
	{
		try
		{
			string query = @"
                    SELECT 
                        o.*, 
                        ol.*
                    FROM 
                        ""Orders"" o
                    LEFT JOIN 
                        ""OrderLines"" ol ON o.""Id"" = ol.""OrderId""
                    WHERE 
                        o.""Id"" = @Id 
                        AND NOT o.""IsDeleted""";

			var ordersLookup = new Dictionary<Guid, Order>();

			await _dbConnection.QueryAsync<Order, OrderLine, Order>(
				query,
				(order, orderLine) =>
				{
					if (!ordersLookup.TryGetValue(order.Id, out Order currentOrder))
					{
						currentOrder = order;
						currentOrder.OrderLines = new List<OrderLine>();
						ordersLookup.Add(currentOrder.Id, currentOrder);
					}

					currentOrder.OrderLines.Add(orderLine);
					return currentOrder;
				},
				new { Id = id },
				splitOn: "Id");

			return ordersLookup.Count > 0 ? ordersLookup[id] : null;
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Order)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Order)), ex);
		}
	}

	public async Task<List<Order>> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellationToken)
	{
		try
		{
			string query = @"
                    SELECT 
                        o.*, 
                        ol.*,
						os.*
                    FROM 
                        ""Orders"" o
                    LEFT JOIN 
                        ""OrderLines"" ol ON o.""Id"" = ol.""OrderId""
					LEFT JOIN
                    ""OrderStatus"" os ON o.""StatusId"" = os.""Id""
                    WHERE 
                        o.""UserId"" = @UserId 
                        AND NOT o.""IsDeleted""";

			var ordersLookup = new Dictionary<Guid, Order>();

			await _dbConnection.QueryAsync<Order, OrderLine, OrderStatus, Order>(
				query,
				(order, orderLine, orderStatus) =>
				{
					if (!ordersLookup.TryGetValue(order.Id, out Order currentOrder))
					{
						currentOrder = order;
						currentOrder.OrderLines = new List<OrderLine>();
						ordersLookup.Add(currentOrder.Id, currentOrder);
					}

					currentOrder.OrderLines.Add(orderLine);
					currentOrder.Status = orderStatus;
					return currentOrder;
				},
				new { UserId = userId },
				splitOn: "Id,Id");

			return new List<Order>(ordersLookup.Values);
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Order)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Order)), ex);
		}
	}
}