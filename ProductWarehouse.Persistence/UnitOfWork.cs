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

    public UnitOfWork(ApplicationDbContext dbContext,
                        IOrderStatusRepository orderStatusRepository,
                        IGroupRepository groupRepository,
                        IProductRepository productRepository,
                        ISizeRepository sizesRepository,
                        IOrderRepository ordersRepository,
                        IBrandRepository brandsRepository
                        )
    {
        _dbContext = dbContext;
        OrdersStatuses = orderStatusRepository;
        Group = groupRepository;
        Products = productRepository;
        Sizes = sizesRepository;
        Orders = ordersRepository;
        Brands = brandsRepository;
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
