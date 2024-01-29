namespace ProductWarehouse.Application.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    ISizeRepository Sizes { get; }
    IOrderRepository Orders { get; }
    IBrandRepository Brands { get; }
    Task<int> SaveChangesAsync();

}
