using Recipes.DbConnector.Models;
using Recipes.DynamicSorting;

namespace Recipes.DbConnector.DynamicSorting;

[TestClass]
public class DynamicSortingTests : DynamicSortingTests<EmployeeSimple>
{
    protected override IDynamicSortingScenario<EmployeeSimple> GetScenario()
    {
        return new DynamicSortingScenario(Setup.SqlServerConnectionString);
    }
}