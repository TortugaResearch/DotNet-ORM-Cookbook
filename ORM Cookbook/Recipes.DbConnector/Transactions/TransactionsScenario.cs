using Recipes.DbConnector.Models;
using Recipes.Transactions;
using System.Data;

namespace Recipes.DbConnector.Transactions;

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
            //Set the custom transaction when invoking Execute
            var result = DbConnector.Scalar<int>(sql, classification).Execute(trans);

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
            //Set the custom transaction when invoking Execute
            var result = DbConnector.Scalar<int>(sql, classification).Execute(trans);

            if (shouldRollBack)
                trans.Rollback();
            else
                trans.Commit();

            return result;
        }
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        string sql = "SELECT * FROM " + EmployeeClassification.TableName + " WHERE EmployeeClassificationKey = @employeeClassificationKey;";

        return DbConnector.ReadFirstOrDefault<EmployeeClassification>(sql, new { employeeClassificationKey })
                           .WithIsolationLevel(IsolationLevel.ReadCommitted) //Enable the use of a transaction
                           .Execute();
    }
}