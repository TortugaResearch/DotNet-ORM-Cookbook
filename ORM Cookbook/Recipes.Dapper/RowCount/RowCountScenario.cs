using Dapper;
using Recipes.Dapper.Models;
using Recipes.RowCount;

namespace Recipes.Dapper.RowCount;

public class RowCountScenario : ScenarioBase, IRowCountScenario<EmployeeSimple>
{
    public RowCountScenario(string connectionString) : base(connectionString)
    { }

    public int EmployeeCount(string lastName)
    {
        const string sql = "SELECT COUNT(*) FROM HR.Employee e WHERE e.LastName = @LastName";
        using (var con = OpenConnection())
            return con.ExecuteScalar<int>(sql, new { lastName });
    }

    public int EmployeeCount()
    {
        const string sql = "SELECT COUNT(*) FROM HR.Employee e";
        using (var con = OpenConnection())
            return con.ExecuteScalar<int>(sql);
    }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        const string sql = @"INSERT INTO HR.Employee
(FirstName, MiddleName, LastName, Title, OfficePhone, CellPhone, EmployeeClassificationKey)
VALUES (@FirstName, @MiddleName, @LastName, @Title, @OfficePhone, @CellPhone, @EmployeeClassificationKey)";
        using (var con = OpenConnection())
            con.Execute(sql, employees);
    }
}