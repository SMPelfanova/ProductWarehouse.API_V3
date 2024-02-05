using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;

namespace ProductWarehouse.Persistence.EF.Repositories;

public sealed class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Order> GetOrderDetails(Guid id)
    {
        //var order = await _dbContext.Orders
        // .Include(o => o.OrderDetails)
        // .Include(o => o.Status)
        // .FirstOrDefaultAsync(o => o.Id == id);
        throw new NotImplementedException();

        //return order;
    }

    public Task<Order> GetOrderStatus(Guid id)
    {
        throw new NotImplementedException();
    }
}