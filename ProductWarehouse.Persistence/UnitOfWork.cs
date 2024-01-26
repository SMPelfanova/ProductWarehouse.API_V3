using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Interfaces;
using ProductWarehouse.Persistence.EF;

namespace ProductWarehouse.Persistence;
internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public IProductRepository Products { get; }

    public UnitOfWork(ApplicationDbContext dbContext,
                        IProductRepository productRepository)
    {
        _dbContext = dbContext;
        Products = productRepository;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }


    public Task<int> SaveChangesAsync()
    {
        return _dbContext.SaveChangesAsync();
    }
}
