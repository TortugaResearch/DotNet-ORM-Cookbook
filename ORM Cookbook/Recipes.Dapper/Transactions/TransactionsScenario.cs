using Dapper;
using Dapper.Contrib.Extensions;
using Recipes.Dapper.Models;
using Recipes.Transactions;
using System.Data;

namespace Recipes.Dapper.Transactions;

public class TransactionsScenario : ScenarioBase, ITransactionsScenario<EmployeeClassification>
{
    public TransactionsScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(EmployeeClassification classification, bool shouldRollBack)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName )";

        using (var con = OpenConnection())
        using (var trans = con.BeginTransaction())
        {
            var result = con.ExecuteScalar<int>(sql, classification, transaction: trans);

            if (shouldRollBack)
                trans.Rollback();
            else
                trans.Commit();

            return result;
        }
    }

    public int CreateWithIsolationLevel(EmployeeClassification classification, bool shouldRollBack, IsolationLevel isolationLevel)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        var sql = @"INSERT INTO HR.EmployeeClassification (EmployeeClassificationName)
                        OUTPUT Inserted.EmployeeClassificationKey
                        VALUES(@EmployeeClassificationName )";

        using (var con = OpenConnection())
        using (var trans = con.BeginTransaction(isolationLevel))
        {
            var result = con.ExecuteScalar<int>(sql, classification, transaction: trans);

            if (shouldRollBack)
                trans.Rollback();
            else
                trans.Commit();

            return result;
        }
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        using (var con = OpenConnection())
            return con.Get<EmployeeClassification>(employeeClassificationKey);
    }
}