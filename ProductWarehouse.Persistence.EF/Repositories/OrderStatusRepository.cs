using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;

namespace ProductWarehouse.Persistence.EF.Repositories;

public sealed class OrderStatusRepository : Repository<OrderStatus>, IOrderStatusRepository
{
    public OrderStatusRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}