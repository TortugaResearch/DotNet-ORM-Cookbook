using Recipes.Chain.Models;
using Recipes.Transactions;
using System.Data;
using Tortuga.Chain;

namespace Recipes.Chain.Transactions;

public class TransactionsScenario : ITransactionsScenario<EmployeeClassification>
{
    readonly SqlServerDataSource m_DataSource;

    public TransactionsScenario(SqlServerDataSource dataSource)
    {
        m_DataSource = dataSource;
    }

    public int Create(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        return m_DataSource.Insert(classification).ToInt32().Execute();
    }

    public int Create(EmployeeClassification classification, bool shouldRollBack)
    {
        using (var trans = m_DataSource.BeginTransaction())
        {
            var result = trans.Insert(classification).ToInt32().Execute();

            if (shouldRollBack)
                trans.Rollback();
            else
                trans.Commit();

            return result;
        }
    }

    public int CreateWithIsolationLevel(EmployeeClassification classification, bool shouldRollBack, IsolationLevel isolationLevel)
    {
        using (var trans = m_DataSource.BeginTransaction(isolationLevel: isolationLevel))
        {
            var result = trans.Insert(classification).ToInt32().Execute();

            if (shouldRollBack)
                trans.Rollback();
            else
                trans.Commit();

            return result;
        }
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        return m_DataSource.GetByKey<EmployeeClassification>(employeeClassificationKey).ToObjectOrNull().Execute();
    }
}