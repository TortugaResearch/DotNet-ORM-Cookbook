using Recipes.NPoco.Models;
using Recipes.DynamicSorting;

namespace Recipes.NPoco.DynamicSorting;

[TestClass]
public class DynamicSortingTests : DynamicSortingTests<EmployeeSimple>
{
    protected override IDynamicSortingScenario<EmployeeSimple> GetScenario()
    {
        return new DynamicSortingScenario(Setup.SqlServerConnectionString);
    }
}