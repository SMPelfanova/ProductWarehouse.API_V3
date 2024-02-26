using Dapper;
using ProductWarehouse.Persistence.Abstractions.Interfaces;
using System.Data;

namespace ProductWarehouse.Persistence.Repositories;
public class DapperRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
	private readonly IDbConnection _connection;
	private readonly IDbTransaction _dbTransaction;


	public DapperRepository(IDbConnection connection, IDbTransaction dbTransaction)
	{
		_connection = connection ?? throw new ArgumentNullException(nameof(connection));
		_dbTransaction = dbTransaction;
	}

	public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
	{
		string query = $"SELECT * FROM {typeof(TEntity).Name}s WHERE Id = @Id";
		return await _connection.QueryFirstOrDefaultAsync<TEntity>(query, new { Id = id }, _dbTransaction);
	}

	public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		string query = $"SELECT * FROM {typeof(TEntity).Name}s";
		var entities = await _connection.QueryAsync<TEntity>(query);
		return entities.ToList().AsReadOnly();
	}

	public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		string query = $@"INSERT INTO {typeof(TEntity).Name}s VALUES (@Id, @Name, @Price)"; // Assuming columns Id, Name, Price
		await _connection.ExecuteAsync(query, entity);
		return entity;
	}

	public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		string query = $"DELETE FROM {typeof(TEntity).Name}s WHERE Id = @Id";
		await _connection.ExecuteAsync(query, new { Id = entity.GetType().GetProperty("Id").GetValue(entity) });
	}

	public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		string query = $@"UPDATE {typeof(TEntity).Name}s SET Name = @Name, Price = @Price WHERE Id = @Id"; // Assuming columns Id, Name, Price
		await _connection.ExecuteAsync(query, entity);
	}


	public async Task<bool> CheckIfExistsAsync(Guid id, CancellationToken cancellationToken = default)
	{
		string query = $"SELECT COUNT(*) FROM {typeof(TEntity).Name}s WHERE Id = @Id";
		var count = await _connection.ExecuteScalarAsync<int>(query, new { Id = id });
		return count > 0;
	}
}