using DbConnector.Core;
using Recipes.DbConnector.Models;
using Recipes.RowCount;
using System.Data;
using System.Data.Common;

namespace Recipes.DbConnector.RowCount;

public class RowCountScenario : ScenarioBase, IRowCountScenario<EmployeeSimple>
{
    public RowCountScenario(string connectionString) : base(connectionString)
    { }

    public int EmployeeCount(string lastName)
    {
        const string sql = "SELECT COUNT(*) FROM HR.Employee e WHERE e.LastName = @lastName";

        return DbConnector.Scalar<int>(sql, new { lastName }).Execute();
    }

    public int EmployeeCount()
    {
        const string sql = "SELECT COUNT(*) FROM HR.Employee e";

        return DbConnector.Scalar<int>(sql).Execute();
    }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        //Best approach for unlimited inserts since SQL server has parameter amount restrictions
        //https://docs.microsoft.com/en-us/sql/sql-server/maximum-capacity-specifications-for-sql-server?redirectedfrom=MSDN&view=sql-server-ver15
        DbConnector.Build<int?>(
                sql: @$"INSERT INTO {EmployeeSimple.TableName}
                    (
                        CellPhone,
                        EmployeeClassificationKey,
                        FirstName,
                        LastName,
                        MiddleName,
                        OfficePhone,
                        Title
                    )
                    VALUES (
                        @{nameof(EmployeeSimple.CellPhone)},
                        @{nameof(EmployeeSimple.EmployeeClassificationKey)},
                        @{nameof(EmployeeSimple.FirstName)},
                        @{nameof(EmployeeSimple.LastName)},
                        @{nameof(EmployeeSimple.MiddleName)},
                        @{nameof(EmployeeSimple.OfficePhone)},
                        @{nameof(EmployeeSimple.Title)}
                    )",
                param: employees[0],
                onExecute: (int? result, IDbExecutionModel em) =>
                {
                    //Set the command
                    DbCommand command = em.Command;

                    //Execute first row.
                    em.NumberOfRowsAffected = command.ExecuteNonQuery();

                    //Set and execute remaining rows.
                    for (int i = 1; i < employees.Count; i++)
                    {
                        var emp = employees[i];

                        command.Parameters[nameof(EmployeeSimple.CellPhone)].Value = emp.CellPhone ?? (object)DBNull.Value;
                        command.Parameters[nameof(EmployeeSimple.EmployeeClassificationKey)].Value = emp.EmployeeClassificationKey;
                        command.Parameters[nameof(EmployeeSimple.FirstName)].Value = emp.FirstName ?? (object)DBNull.Value;
                        command.Parameters[nameof(EmployeeSimple.LastName)].Value = emp.LastName ?? (object)DBNull.Value;
                        command.Parameters[nameof(EmployeeSimple.MiddleName)].Value = emp.MiddleName ?? (object)DBNull.Value;
                        command.Parameters[nameof(EmployeeSimple.OfficePhone)].Value = emp.OfficePhone ?? (object)DBNull.Value;
                        command.Parameters[nameof(EmployeeSimple.Title)].Value = emp.Title ?? (object)DBNull.Value;

                        em.NumberOfRowsAffected += command.ExecuteNonQuery();
                    }

                    return em.NumberOfRowsAffected;
                }
            )
            .WithIsolationLevel(IsolationLevel.ReadCommitted)//Use a transaction
            .Execute();
    }
}