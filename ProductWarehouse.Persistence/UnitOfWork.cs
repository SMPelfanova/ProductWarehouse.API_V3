using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Persistence.EF;

namespace ProductWarehouse.Persistence;
internal class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;
    public IProductRepository Products { get; }

    public ISizeRepository Sizes { get; }

    public IOrderRepository Orders { get; }

    public IBrandRepository Brands { get; }

    public IOrderStatusRepository OrdersStatuses { get; }
    public IGroupRepository Group { get; }

    public IBasketRepository Basket { get; }

    public IUserRepository User { get; }

    public UnitOfWork(ApplicationDbContext dbContext,
                        IOrderStatusRepository orderStatusRepository,
                        IGroupRepository groupRepository,
                        IProductRepository productRepository,
                        ISizeRepository sizesRepository,
                        IOrderRepository ordersRepository,
                        IBrandRepository brandsRepository,
                        IUserRepository userRepository,
                        IBasketRepository basketRepository
                        )
    {
        _dbContext = dbContext;
        OrdersStatuses = orderStatusRepository;
        Group = groupRepository;
        Products = productRepository;
        Sizes = sizesRepository;
        Orders = ordersRepository;
        Brands = brandsRepository;
        Basket = basketRepository;
        User = userRepository;
    }

    public Task<int> SaveChangesAsync()
    {
        return _dbContext.SaveChangesAsync();
    }

    public void Rollback()
    {
        _dbContext.Database.RollbackTransaction();
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }
}
