using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using Serilog;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class OrderStatusRepository : Repository<OrderStatus>, IOrderStatusRepository
{
	public OrderStatusRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
	{
	}
}