using Recipes.ServiceStack.Entities;
using Recipes.Transactions;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Data;

namespace Recipes.ServiceStack.Transactions;

internal class TransactionsScenario : ITransactionsScenario<EmployeeClassification>
{
    private IDbConnectionFactory _dbConnectionFactory;

    public TransactionsScenario(IDbConnectionFactory dbConnectionFactory)
    {
        this._dbConnectionFactory = dbConnectionFactory;
    }

    public int Create(EmployeeClassification classification, bool shouldRollBack)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            using (var tx = db.OpenTransaction())
            {
                var result = (int)db.Insert(classification, true);

                if (shouldRollBack)
                    tx.Rollback();
                else
                    tx.Commit();

                return result;
            }
        }
    }

    public int CreateWithIsolationLevel(EmployeeClassification classification, bool shouldRollBack, IsolationLevel isolationLevel)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            using (var tx = db.OpenTransaction(isolationLevel))
            {
                var result = (int)db.Insert(classification, true);

                if (shouldRollBack)
                    tx.Rollback();
                else
                    tx.Commit();

                return result;
            }
        }
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.SingleById<EmployeeClassification>(employeeClassificationKey);
    }
}