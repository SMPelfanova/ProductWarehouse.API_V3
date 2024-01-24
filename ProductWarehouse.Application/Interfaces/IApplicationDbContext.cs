using Microsoft.EntityFrameworkCore;
using ProductWarehouse.Domain.Entities;

namespace ProductWarehouse.Application.Interfaces;
public interface IApplicationDbContext
{
    DbSet<Product> Products { get; set; }
    DbSet<Order> Orders { get; set; }
    Task<int> SaveChanges(CancellationToken cancellationToken = default);

}
