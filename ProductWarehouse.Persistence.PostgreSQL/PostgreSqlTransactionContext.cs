using Npgsql;
using ProductWarehouse.Application.Interfaces;

namespace ProductWarehouse.Persistence.PostgreSQL;
public class PostgreSqlTransactionContext : IPostgreSqlTransactionContext
{
	private NpgsqlConnection _connection;
	private NpgsqlTransaction _transaction;


	public PostgreSqlTransactionContext(string connectionString)
	{
		_connection = new NpgsqlConnection(connectionString);
	}

	public void BeginTransaction()
	{
		_connection.Open();
		_transaction = _connection.BeginTransaction();
	}

	public void CommitTransaction()
	{
		_transaction.Commit();
	}

	public void RollbackTransaction()
	{
		_transaction.Rollback();
	}

	public void Dispose()
	{
		if (_transaction != null)
		{
			_transaction.Dispose();
		}
		if (_connection != null)
		{
			_connection.Close();
			_connection.Dispose();
		}
	}
}