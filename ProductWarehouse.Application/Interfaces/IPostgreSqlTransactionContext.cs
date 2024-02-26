namespace ProductWarehouse.Application.Interfaces;
public interface IPostgreSqlTransactionContext : IDisposable
{
	void BeginTransaction();
	void CommitTransaction();
	void RollbackTransaction();
}

