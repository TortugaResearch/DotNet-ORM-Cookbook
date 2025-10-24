using Recipes.RepoDB.Models;
using Recipes.Sorting;

namespace Recipes.RepoDB.Sorting;

[TestClass]
public class SortingTests : SortingTests<EmployeeSimple>
{
    protected override ISortingScenario<EmployeeSimple> GetScenario()
    {
        return new SortingScenario(Setup.ConnectionString);
    }
}