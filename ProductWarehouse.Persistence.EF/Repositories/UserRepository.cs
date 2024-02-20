using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using Serilog;

namespace ProductWarehouse.Persistence.EF.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
	public UserRepository(ApplicationDbContext dbContext, ILogger logger) : base(dbContext, logger)
	{
	}
}