using ProductWarehouse.Domain.Interfaces;

namespace ProductWarehouse.Application.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }

    Task<bool> SaveChangesAsync();

}
