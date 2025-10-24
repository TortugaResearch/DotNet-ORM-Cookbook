using Recipes.Dapper.Models;
using Recipes.Sorting;

namespace Recipes.Dapper.Sorting;

[TestClass]
public class SortingTests : SortingTests<EmployeeSimple>
{
    protected override ISortingScenario<EmployeeSimple> GetScenario()
    {
        return new SortingScenario(Setup.SqlServerConnectionString);
    }
}