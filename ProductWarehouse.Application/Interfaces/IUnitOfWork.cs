using ProductWarehouse.Domain.Interfaces;

namespace ProductWarehouse.Application.Interfaces;
public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync();

}
