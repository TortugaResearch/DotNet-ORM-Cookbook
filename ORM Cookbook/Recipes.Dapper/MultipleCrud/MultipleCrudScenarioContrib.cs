using Dapper.Contrib.Extensions;
using Recipes.Dapper.Models;

namespace Recipes.Dapper.MultipleCrud;

public class MultipleCrudScenarioContrib : MultipleCrudScenario
{
    public MultipleCrudScenarioContrib(string connectionString) : base(connectionString)
    { }

    override public void DeleteBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var con = OpenConnection())
            con.Delete(employees);
    }

    override public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var con = OpenConnection())
            con.Insert(employees);
    }

    override public void UpdateBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var con = OpenConnection())
            con.Update(employees);
    }
}