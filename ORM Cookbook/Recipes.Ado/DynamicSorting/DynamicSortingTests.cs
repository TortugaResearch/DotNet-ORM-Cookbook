using Recipes.Ado.Models;
using Recipes.DynamicSorting;

namespace Recipes.Ado.DynamicSorting;

[TestClass]
public class DynamicSortingTests : DynamicSortingTests<EmployeeSimple>
{
    protected override IDynamicSortingScenario<EmployeeSimple> GetScenario()
    {
        return new DynamicSortingScenario(Setup.SqlServerConnectionString);
    }
}