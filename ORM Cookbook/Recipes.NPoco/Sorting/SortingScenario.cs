using Recipes.NPoco.Models;
using Recipes.Sorting;

namespace Recipes.NPoco.Sorting;

public class SortingScenario : ScenarioBase, ISortingScenario<EmployeeSimple>
{
    public SortingScenario(string connectionString) : base(connectionString)
    {
    }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        throw new NotImplementedException();
    }

    public IList<EmployeeSimple> SortByFirstName(string lastName)
    {
        throw new NotImplementedException();
    }

    public IList<EmployeeSimple> SortByMiddleNameDescFirstName(string lastName)
    {
        throw new NotImplementedException();
    }

    public IList<EmployeeSimple> SortByMiddleNameFirstName(string lastName)
    {
        throw new NotImplementedException();
    }
}