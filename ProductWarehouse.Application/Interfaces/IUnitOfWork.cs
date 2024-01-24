using ProductWarehouse.Domain.Interfaces;

namespace ProductWarehouse.Application.Interfaces;
public interface IUnitOfWork : IDisposable
{
    void Commit();
    void Rallback();
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
}
