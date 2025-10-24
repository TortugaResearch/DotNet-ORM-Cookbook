using Microsoft.Data.SqlClient;
using Recipes.Ado.Models;
using Recipes.DynamicSorting;
using System.Text;

namespace Recipes.Ado.DynamicSorting;

public class DynamicSortingScenario : SqlServerScenarioBase, IDynamicSortingScenario<EmployeeSimple>
{
    public DynamicSortingScenario(string connectionString) : base(connectionString)
    { }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        var sql = new StringBuilder(@"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
VALUES ");

        for (var i = 0; i < employees.Count; i++)
        {
            if (i != 0)
                sql.AppendLine(",");
            sql.Append($"(@FirstName_{i}, @MiddleName_{i}, @LastName_{i}, @Title_{i}, @OfficePhone_{i}, " +
                $"@CellPhone_{i}, @EmployeeClassificationKey_{i})");
        }
        sql.AppendLine(";");

        //No transaction is needed because a single SQL statement is used.
        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql.ToString(), con))
        {
            for (var i = 0; i < employees.Count; i++)
            {
                cmd.Parameters.AddWithValue($"@FirstName_{i}", employees[i].FirstName);
                cmd.Parameters.AddWithValue($"@MiddleName_{i}", (object?)employees[i].MiddleName ?? DBNull.Value);
                cmd.Parameters.AddWithValue($"@LastName_{i}", employees[i].LastName);
                cmd.Parameters.AddWithValue($"@Title_{i}", (object?)employees[i].Title ?? DBNull.Value);
                cmd.Parameters.AddWithValue($"@OfficePhone_{i}", (object?)employees[i].OfficePhone ?? DBNull.Value);
                cmd.Parameters.AddWithValue($"@CellPhone_{i}", (object?)employees[i].CellPhone ?? DBNull.Value);
                cmd.Parameters.AddWithValue($"@EmployeeClassificationKey_{i}",
                    employees[i].EmployeeClassificationKey);
            }
            cmd.ExecuteNonQuery();
        }
    }

    public IList<EmployeeSimple> SortBy(string lastName, string sortByColumn, bool isDescending)
    {
        if (!Utilities.EmployeeColumnNames.Contains(sortByColumn))
            throw new ArgumentOutOfRangeException(nameof(sortByColumn), "Unknown column " + sortByColumn);

        var sortDirection = isDescending ? "DESC " : "";

        var sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, " +
            "e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e WHERE e.LastName = @LastName " +
            $"ORDER BY [{sortByColumn}] {sortDirection}";

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@LastName", lastName);

            var results = new List<EmployeeSimple>();

            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    results.Add(new EmployeeSimple(reader));

            return results;
        }
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

        var sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, " +
            "e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e WHERE e.LastName = @LastName " +
            $"ORDER BY [{sortByColumnA}] {sortDirectionA}, [{sortByColumnB}] {sortDirectionB}";

        using (var con = OpenConnection())
        using (var cmd = new SqlCommand(sql, con))
        {
            cmd.Parameters.AddWithValue("@LastName", lastName);

            var results = new List<EmployeeSimple>();

            using (var reader = cmd.ExecuteReader())
                while (reader.Read())
                    results.Add(new EmployeeSimple(reader));

            return results;
        }
    }
}