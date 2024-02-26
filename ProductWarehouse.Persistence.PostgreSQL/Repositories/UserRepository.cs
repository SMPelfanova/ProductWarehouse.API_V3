using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using Serilog;
using System.Data;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
	public UserRepository(
		ApplicationDbContext dbContext,
		IDbConnection dbConnection,
		IDbTransaction dbTransaction,
		ILogger logger) : base(dbContext, dbConnection, dbTransaction, logger)
	{
	}
}