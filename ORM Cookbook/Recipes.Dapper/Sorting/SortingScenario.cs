using Dapper;
using Dapper.Contrib.Extensions;
using Recipes.Dapper.Models;
using Recipes.Sorting;

namespace Recipes.Dapper.Sorting;

public class SortingScenario : ScenarioBase, ISortingScenario<EmployeeSimple>
{
    public SortingScenario(string connectionString) : base(connectionString)
    {
    }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var con = OpenConnection())
            con.Insert(employees);
    }

    public IList<EmployeeSimple> SortByFirstName(string lastName)
    {
        const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, " +
            "e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e WHERE e.LastName = @LastName " +
            "ORDER BY e.FirstName";

        using (var con = OpenConnection())
            return con.Query<EmployeeSimple>(sql, new { lastName }).ToList();
    }

    public IList<EmployeeSimple> SortByMiddleNameDescFirstName(string lastName)
    {
        const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, " +
            "e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e WHERE e.LastName = @LastName " +
            "ORDER BY e.MiddleName DESC, e.FirstName";

        using (var con = OpenConnection())
            return con.Query<EmployeeSimple>(sql, new { lastName }).ToList();
    }

    public IList<EmployeeSimple> SortByMiddleNameFirstName(string lastName)
    {
        const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, " +
            "e.CellPhone, e.EmployeeClassificationKey FROM HR.Employee e WHERE e.LastName = @LastName " +
            "ORDER BY e.MiddleName, e.FirstName";

        using (var con = OpenConnection())
            return con.Query<EmployeeSimple>(sql, new { lastName }).ToList();
    }
}