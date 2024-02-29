using ProductWarehouse.Application.Interfaces;
using ProductWarehouse.Domain.Entities;
using ProductWarehouse.Persistence.Abstractions;
using Serilog;
using System.Data;

namespace ProductWarehouse.Persistence.PostgreSQL.Repositories;

public class SizeRepository : Repository<Size>, ISizeRepository
{
	public SizeRepository(ApplicationDbContext dbContext, IDbConnection dbConnection, ILogger logger) : base(dbContext, dbConnection, logger)
	{
	}
}