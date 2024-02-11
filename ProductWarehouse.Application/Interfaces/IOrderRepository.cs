using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions.Interfaces;

namespace ProductWarehouse.Application.Interfaces;
public interface IOrderRepository : IRepository<Order>
{
    Task<List<Order>> GetOrdersByUserIdAsync(Guid userId);
    Task<Order> GetOrderStatusAsync(Guid id);
    Task<Order> GetOrderDetailsAsync(Guid id);
}
