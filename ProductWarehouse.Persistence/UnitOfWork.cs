using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Interfaces;

namespace ProductWarehouse.Persistence;
internal class UnitOfWork : IUnitOfWork
{
    public void Commit()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        throw new NotImplementedException();
    }

    public void Rallback()
    {
        throw new NotImplementedException();
    }
}
