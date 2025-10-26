using Recipes.NPoco.Models;
using Recipes.RowCount;

namespace Recipes.NPoco.RowCount;

public class RowCountScenario : ScenarioBase, IRowCountScenario<EmployeeSimple>
{
    public RowCountScenario(string connectionString) : base(connectionString)
    { }

    public int EmployeeCount(string lastName)
    {
        throw new NotImplementedException();
    }

    public int EmployeeCount()
    {
        throw new NotImplementedException();
    }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        throw new NotImplementedException();
    }
}