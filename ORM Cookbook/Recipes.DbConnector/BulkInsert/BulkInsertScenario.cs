using Microsoft.Data.SqlClient;
using Recipes.BulkInsert;
using Recipes.DbConnector.Models;
using System.Data;

namespace Recipes.DbConnector.BulkInsert;

public class BulkInsertScenario : ScenarioBase, IBulkInsertScenario<EmployeeSimple>
{
    public BulkInsertScenario(string connectionString) : base(connectionString)
    { }

    public int CountByLastName(string lastName)
    {
        const string sql = "SELECT Count(*) FROM HR.EmployeeDetail e WHERE e.LastName = @lastName";

        return DbConnector.Scalar<int>(sql, new { lastName }).Execute();
    }

    public void BulkInsert(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        DataTable dtEmployees = Utilities.CopyToDataTable(employees);

        //This implementation is ADO.NET "data provider specific" therefore DbConnector is not involved
        using (var con = OpenConnection())
        using (var sbc = new SqlBulkCopy(con))
        {
            sbc.DestinationTableName = "HR.Employee";
            foreach (DataColumn? column in dtEmployees.Columns)
                sbc.ColumnMappings.Add(column!.ColumnName, column.ColumnName);
            sbc.WriteToServer(dtEmployees);
        }
    }

    public void BulkInsert(DataTable employees)
    {
        if (employees == null)
            throw new ArgumentNullException(nameof(employees), $"{nameof(employees)} is null.");

        //This implementation is ADO.NET "data provider specific" therefore DbConnector is not involved
        using (var con = OpenConnection())
        using (var sbc = new SqlBulkCopy(con))
        {
            sbc.DestinationTableName = "HR.Employee";
            foreach (DataColumn? column in employees.Columns)
                sbc.ColumnMappings.Add(column!.ColumnName, column.ColumnName);
            sbc.WriteToServer(employees);
        }
    }
}