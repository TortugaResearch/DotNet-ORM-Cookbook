using Recipes.Dapper.Models;
using Recipes.DynamicSorting;

namespace Recipes.Dapper.DynamicSorting;

[TestClass]
public class DynamicSortingTests : DynamicSortingTests<EmployeeSimple>
{
    protected override IDynamicSortingScenario<EmployeeSimple> GetScenario()
    {
        return new DynamicSortingScenario(Setup.SqlServerConnectionString);
    }
}