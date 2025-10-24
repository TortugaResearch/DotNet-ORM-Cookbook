using Recipes.DbConnector.Models;
using Recipes.Sorting;

namespace Recipes.DbConnector.Sorting;

[TestClass]
public class SortingTests : SortingTests<EmployeeSimple>
{
    protected override ISortingScenario<EmployeeSimple> GetScenario()
    {
        return new SortingScenario(Setup.SqlServerConnectionString);
    }
}