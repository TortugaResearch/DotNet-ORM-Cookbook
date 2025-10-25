using Microsoft.Data.SqlClient;
using Recipes.RepoDB.Models;
using Recipes.Transactions;
using RepoDb;
using System.Data;

using RDB = RepoDb;

namespace Recipes.RepoDB.Transactions;

public class TransactionsScenario(string connectionString) : ITransactionsScenario<EmployeeClassification>
{
    public int Create(EmployeeClassification classification, bool shouldRollBack)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var repository = new EmployeeClassificationRepository(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

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

        var repository = new EmployeeClassificationRepository(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

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
        var repository = new EmployeeClassificationRepository(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.Query(e => e.EmployeeClassificationKey == employeeClassificationKey).FirstOrDefault();
    }
}