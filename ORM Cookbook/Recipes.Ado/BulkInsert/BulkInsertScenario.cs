using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.BulkInsert;
using System;
using System.Collections.Generic;
using System.Data;

namespace Recipes.Ado.BulkInsert
{
    public class BulkInsertScenario : SqlServerScenarioBase, IBulkInsertScenario<EmployeeSimple>
    {
        public BulkInsertScenario(string connectionString) : base(connectionString)
        { }

        public int CountByLastName(string lastName)
        {
            const string sql = "SELECT Count(*) FROM HR.EmployeeDetail e WHERE e.LastName = @LastName";
            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@LastName", lastName);
                return (int)cmd.ExecuteScalar();
            }
        }

        public void BulkInsert(IList<EmployeeSimple> employees)
        {
            if (employees == null || employees.Count == 0)
                throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

            var dataaTable = Utilities.CopyToDataTable(employees);

            using (var con = OpenConnection())
            using (var sbc = new SqlBulkCopy(con))
            {
                sbc.DestinationTableName = "HR.Employee";
                foreach (DataColumn? column in dataaTable.Columns)
                    sbc.ColumnMappings.Add(column!.ColumnName, column.ColumnName);
                sbc.WriteToServer(dataaTable);
            }
        }

        public void BulkInsert(DataTable employees)
        {
            if (employees == null)
                throw new ArgumentNullException(nameof(employees), $"{nameof(employees)} is null.");

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
}
