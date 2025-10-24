using DbConnector.Core;
using DbConnector.Core.Extensions;
using Recipes.DbConnector.Models;
using Recipes.MultipleCrud;
using System.Data;
using System.Data.Common;

namespace Recipes.DbConnector.MultipleCrud;

public class MultipleCrudScenario : ScenarioBase, IMultipleCrudScenario<EmployeeSimple>
{
    public MultipleCrudScenario(string connectionString) : base(connectionString)
    { }

    public void DeleteBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        var keyList = string.Join(", ", employees.Select(x => x.EmployeeKey));
        var sql = $"DELETE FROM HR.Employee WHERE EmployeeKey IN ({keyList});";

        DbConnector.NonQuery(sql).Execute();
    }

    public void DeleteBatchByKey(IList<int> employeeKeys)
    {
        if (employeeKeys == null || employeeKeys.Count == 0)
            throw new ArgumentException($"{nameof(employeeKeys)} is null or empty.", nameof(employeeKeys));

        var keyList = string.Join(", ", employeeKeys);
        var sql = $"DELETE FROM HR.Employee WHERE EmployeeKey IN ({keyList});";

        DbConnector.NonQuery(sql).Execute();
    }

    public IList<EmployeeSimple> FindByLastName(string lastName)
    {
        const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey FROM HR.EmployeeDetail e WHERE e.LastName = @lastName";

        return DbConnector.ReadToList<EmployeeSimple>(sql, new { lastName }).Execute();
    }

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

    public IList<int> InsertBatchReturnKeys(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        string sql = @$"INSERT INTO {EmployeeSimple.TableName}
                            (
                                CellPhone,
                                EmployeeClassificationKey,
                                FirstName,
                                LastName,
                                MiddleName,
                                OfficePhone,
                                Title
                            )
                            OUTPUT Inserted.EmployeeKey
                            VALUES (
                                @{nameof(EmployeeSimple.CellPhone)},
                                @{nameof(EmployeeSimple.EmployeeClassificationKey)},
                                @{nameof(EmployeeSimple.FirstName)},
                                @{nameof(EmployeeSimple.LastName)},
                                @{nameof(EmployeeSimple.MiddleName)},
                                @{nameof(EmployeeSimple.OfficePhone)},
                                @{nameof(EmployeeSimple.Title)}
                            )";

        //Best approach since SQL server has parameter amount restrictions
        //https://docs.microsoft.com/en-us/sql/sql-server/maximum-capacity-specifications-for-sql-server?redirectedfrom=MSDN&view=sql-server-ver15
        return DbConnector.ReadTo<List<int>>(
                 onInit: (cmds) =>
                 {
                     foreach (var emp in employees)
                     {
                         cmds.Enqueue(cmd =>
                         {
                             cmd.CommandText = sql;
                             cmd.CommandBehavior = CommandBehavior.SingleResult;
                             cmd.Parameters.AddFor(emp);
                         });
                     }
                 },
                 onLoad: (List<int> data, IDbExecutionModel em, DbDataReader odr) =>
                 {
                     if (data == null)
                         data = new List<int>();

                     data.Add(odr.SingleOrDefault<int>(em.Token, em.JobCommand));

                     return data;
                 }
             )
            .WithIsolationLevel(IsolationLevel.ReadCommitted)//Use a transaction
            .Execute();
    }

    public IList<EmployeeSimple> InsertBatchReturnRows(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        string sql = @$"INSERT INTO {EmployeeSimple.TableName}
                            (
                                CellPhone,
                                EmployeeClassificationKey,
                                FirstName,
                                LastName,
                                MiddleName,
                                OfficePhone,
                                Title
                            )
                            OUTPUT Inserted.EmployeeKey, Inserted.FirstName, Inserted.MiddleName, Inserted.LastName, Inserted.Title, Inserted.OfficePhone, Inserted.CellPhone, Inserted.EmployeeClassificationKey
                            VALUES (
                                @{nameof(EmployeeSimple.CellPhone)},
                                @{nameof(EmployeeSimple.EmployeeClassificationKey)},
                                @{nameof(EmployeeSimple.FirstName)},
                                @{nameof(EmployeeSimple.LastName)},
                                @{nameof(EmployeeSimple.MiddleName)},
                                @{nameof(EmployeeSimple.OfficePhone)},
                                @{nameof(EmployeeSimple.Title)}
                            )";

        //Best approach since SQL server has parameter amount restrictions
        //https://docs.microsoft.com/en-us/sql/sql-server/maximum-capacity-specifications-for-sql-server?redirectedfrom=MSDN&view=sql-server-ver15
        return DbConnector.ReadTo<List<EmployeeSimple>>(
                 onInit: (cmds) =>
                 {
                     foreach (var emp in employees)
                     {
                         cmds.Enqueue(cmd =>
                         {
                             cmd.CommandText = sql;
                             cmd.CommandBehavior = CommandBehavior.SingleResult;
                             cmd.Parameters.AddFor(emp);
                         });
                     }
                 },
                 onLoad: (List<EmployeeSimple> data, IDbExecutionModel em, DbDataReader odr) =>
                 {
                     if (data == null)
                         data = new List<EmployeeSimple>();

                     data.Add(odr.SingleOrDefault<EmployeeSimple>(em.Token, em.JobCommand));

                     return data;
                 }
             )
            .WithIsolationLevel(IsolationLevel.ReadCommitted)//Use a transaction
            .Execute();
    }

    public void InsertBatchWithRefresh(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        string sql = @$"INSERT INTO {EmployeeSimple.TableName}
                            (
                                CellPhone,
                                EmployeeClassificationKey,
                                FirstName,
                                LastName,
                                MiddleName,
                                OfficePhone,
                                Title
                            )
                            OUTPUT Inserted.EmployeeKey, Inserted.FirstName, Inserted.MiddleName, Inserted.LastName, Inserted.Title, Inserted.OfficePhone, Inserted.CellPhone, Inserted.EmployeeClassificationKey
                            VALUES (
                                @{nameof(EmployeeSimple.CellPhone)},
                                @{nameof(EmployeeSimple.EmployeeClassificationKey)},
                                @{nameof(EmployeeSimple.FirstName)},
                                @{nameof(EmployeeSimple.LastName)},
                                @{nameof(EmployeeSimple.MiddleName)},
                                @{nameof(EmployeeSimple.OfficePhone)},
                                @{nameof(EmployeeSimple.Title)}
                            )";

        //Best approach since SQL server has parameter amount restrictions
        //https://docs.microsoft.com/en-us/sql/sql-server/maximum-capacity-specifications-for-sql-server?redirectedfrom=MSDN&view=sql-server-ver15
        DbConnector.ReadTo<bool>(
                 onInit: (cmds) =>
                 {
                     foreach (var emp in employees)
                     {
                         cmds.Enqueue(cmd =>
                         {
                             cmd.CommandText = sql;
                             cmd.CommandBehavior = CommandBehavior.SingleResult;
                             cmd.Parameters.AddFor(emp);
                         });
                     }
                 },
                 onLoad: (bool result, IDbExecutionModel em, DbDataReader odr) =>
                 {
                     employees[em.Index].Refresh(odr.SingleOrDefault<EmployeeSimple>(em.Token, em.JobCommand));
                     return true;
                 }
             )
            .WithIsolationLevel(IsolationLevel.ReadCommitted)//Use a transaction
            .Execute();
    }

    public void UpdateBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || !employees.Any())
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        //Best approach since SQL server has parameter amount restrictions
        //https://docs.microsoft.com/en-us/sql/sql-server/maximum-capacity-specifications-for-sql-server?redirectedfrom=MSDN&view=sql-server-ver15
        DbConnector.Build<int?>(
                sql: @$"UPDATE {EmployeeSimple.TableName}
                    SET
                        CellPhone = @{nameof(EmployeeSimple.CellPhone)},
                        EmployeeClassificationKey = @{nameof(EmployeeSimple.EmployeeClassificationKey)},
                        FirstName = @{nameof(EmployeeSimple.FirstName)},
                        LastName = @{nameof(EmployeeSimple.LastName)},
                        MiddleName = @{nameof(EmployeeSimple.MiddleName)},
                        OfficePhone = @{nameof(EmployeeSimple.OfficePhone)},
                        Title = @{nameof(EmployeeSimple.Title)}
                    WHERE EmployeeKey = @{nameof(EmployeeSimple.EmployeeKey)}",
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
                        command.Parameters[nameof(EmployeeSimple.EmployeeKey)].Value = emp.EmployeeKey;
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