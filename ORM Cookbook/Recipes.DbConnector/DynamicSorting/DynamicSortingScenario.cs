using DbConnector.Core;
using Recipes.DbConnector.Models;
using Recipes.DynamicSorting;
using System.Data;
using System.Data.Common;

namespace Recipes.DbConnector.DynamicSorting;

public class DynamicSortingScenario : ScenarioBase, IDynamicSortingScenario<EmployeeSimple>
{
    public DynamicSortingScenario(string connectionString) : base(connectionString)
    { }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || !employees.Any())
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
                param: employees.First(),
                onExecute: (int? result, IDbExecutionModel em) =>
                {
                    //Set the command
                    DbCommand command = em.Command;

                    //Execute first row.
                    em.NumberOfRowsAffected = command.ExecuteNonQuery();

                    //Set and execute remaining rows.
                    foreach (var emp in employees.Skip(1))
                    {
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

    public IList<EmployeeSimple> SortBy(string lastName, string sortByColumn, bool isDescending)
    {
        if (!Utilities.EmployeeColumnNames.Contains(sortByColumn))
            throw new ArgumentOutOfRangeException(nameof(sortByColumn), "Unknown column " + sortByColumn);

        var sortDirection = isDescending ? "DESC " : "";

        var sql = @$"SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey
                FROM HR.Employee e
                WHERE e.LastName = @lastName
                ORDER BY [{sortByColumn}] {sortDirection}";

        return DbConnector.ReadToList<EmployeeSimple>(sql, new { lastName }).Execute();
    }

    public IList<EmployeeSimple> SortBy(string lastName, string sortByColumnA, bool isDescendingA,
        string sortByColumnB, bool isDescendingB)
    {
        if (!Utilities.EmployeeColumnNames.Contains(sortByColumnA))
            throw new ArgumentOutOfRangeException(nameof(sortByColumnA), "Unknown column " + sortByColumnA);
        if (!Utilities.EmployeeColumnNames.Contains(sortByColumnB))
            throw new ArgumentOutOfRangeException(nameof(sortByColumnB), "Unknown column " + sortByColumnB);

        var sortDirectionA = isDescendingA ? "DESC " : "";
        var sortDirectionB = isDescendingB ? "DESC " : "";

        var sql = @$"SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey
                FROM HR.Employee e
                WHERE e.LastName = @lastName
                ORDER BY [{sortByColumnA}] {sortDirectionA}, [{sortByColumnB}] {sortDirectionB}";

        return DbConnector.ReadToList<EmployeeSimple>(sql, new { lastName }).Execute();
    }
}