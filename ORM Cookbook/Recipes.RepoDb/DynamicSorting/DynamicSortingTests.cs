using Recipes.DynamicSorting;
using Recipes.RepoDB.Models;

namespace Recipes.RepoDB.DynamicSorting;

[TestClass]
public class DynamicSortingTests : DynamicSortingTests<EmployeeSimple>
{
    protected override IDynamicSortingScenario<EmployeeSimple> GetScenario()
    {
        return new DynamicSortingScenario(Setup.ConnectionString);
    }
}