﻿using Dapper;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using ProductWarehouse.Persistence.Abstractions.Exceptions;
using ProductWarehouse.Persistence.PostgreSQL.Constants;
using ProductWarehouse.Persistence.PostgreSQL.Constants.Dapper;
using Serilog;
using System.Data;
using static Dapper.SqlMapper;

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
		var ordersLookup = new Dictionary<Guid, Order>();
		try
		{
			await _dbConnection.QueryAsync<Order, OrderLine, Order>(
                QueryConstants.GetOrderDetailsQuery,
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
				splitOn: $"{nameof(Order.Id)}");
		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Order)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Order)), ex);
		}

		if (ordersLookup is null || ordersLookup.Count is 0)
		{
			_logger.Warning($"Orders not found.");
			throw new NotFoundException($"Orders not found.");
		}

		return ordersLookup.Count > 0 ? ordersLookup[id] : null;
	}

	public async Task<List<Order>> GetOrdersByUserIdAsync(Guid userId, CancellationToken cancellationToken)
	{
		var ordersLookup = new Dictionary<Guid, Order>();

		try
		{
			await _dbConnection.QueryAsync<Order, OrderLine, OrderStatus, Order>(
				QueryConstants.GetOrdersByUserIdQuery,
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
				splitOn: $"{nameof(OrderLine.Id)},{nameof(OrderStatus.Id)}");

		}
		catch (Exception ex)
		{
			_logger.Error(MessageConstants.GeneralErrorMessage(nameof(Order)), ex);
			throw new DatabaseException(MessageConstants.GeneralErrorMessage(nameof(Order)), ex);
		}

		if (ordersLookup is null || ordersLookup.Count is 0)
		{
			_logger.Warning($"Order not found.");
			throw new NotFoundException($"Order not found.");
		}

		return new List<Order>(ordersLookup.Values);
	}
}