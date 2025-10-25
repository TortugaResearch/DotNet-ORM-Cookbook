using Recipes.RepoDB.Models;
using Recipes.Transactions;
using RepoDb;
using RepoDb.Enumerations;
using System.Data;

namespace Recipes.RepoDB.Transactions;

public class TransactionsScenario : ITransactionsScenario<EmployeeClassification>
{
    readonly string m_ConnectionString;

    public TransactionsScenario(string connectionString)
    {
        m_ConnectionString = connectionString;
    }

    public int Create(EmployeeClassification classification, bool shouldRollBack)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance);

        using (var transaction = repository.CreateConnection().EnsureOpen().BeginTransaction())
        {
            var result = repository.Insert<int>(classification, transaction: transaction);

            if (shouldRollBack)
                transaction.Rollback();
            else
                transaction.Commit();

            return result;
        }
    }

    public int CreateWithIsolationLevel(EmployeeClassification classification, bool shouldRollBack, IsolationLevel isolationLevel)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance);

        using (var transaction = repository.CreateConnection().EnsureOpen().BeginTransaction(isolationLevel))
        {
            var result = repository.Insert<int>(classification, transaction: transaction);

            if (shouldRollBack)
                transaction.Rollback();
            else
                transaction.Commit();

            return result;
        }
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance);

        return repository.Query(e => e.EmployeeClassificationKey == employeeClassificationKey).FirstOrDefault();
    }
}