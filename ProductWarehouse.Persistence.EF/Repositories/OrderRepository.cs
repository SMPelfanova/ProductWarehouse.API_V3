using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;

namespace ProductWarehouse.Persistence.EF.Repositories;

public sealed class OrderRepository : Repository<Order>, IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order> GetOrderDetails(Guid id)
    {
        var order = await _dbContext.Orders
         .Include(o => o.OrderLines)
         .Include(o => o.Status)
         .FirstOrDefaultAsync(o => o.Id == id);

        return order;
    }

    public Task<Order> GetOrderStatus(Guid id)
    {
        throw new NotImplementedException();
    }
}