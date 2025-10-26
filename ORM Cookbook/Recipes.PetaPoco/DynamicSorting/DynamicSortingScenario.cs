using Recipes.DynamicSorting;
using Recipes.PetaPoco.Models;

namespace Recipes.PetaPoco.DynamicSorting;

public class DynamicSortingScenario : ScenarioBase, IDynamicSortingScenario<EmployeeSimple>
{
    public DynamicSortingScenario(string connectionString) : base(connectionString)
    { }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        throw new NotImplementedException();
    }

    public IList<EmployeeSimple> SortBy(string lastName, string sortByColumn, bool isDescending)
    {
        throw new NotImplementedException();
    }

    public IList<EmployeeSimple> SortBy(string lastName, string sortByColumnA, bool isDescendingA,
        string sortByColumnB, bool isDescendingB)
    {
        throw new NotImplementedException();
    }
}