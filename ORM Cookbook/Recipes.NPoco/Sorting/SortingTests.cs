using Recipes.NPoco.Models;
using Recipes.Sorting;

namespace Recipes.NPoco.Sorting;

[TestClass]
public class SortingTests : SortingTests<EmployeeSimple>
{
    protected override ISortingScenario<EmployeeSimple> GetScenario()
    {
        return new SortingScenario(Setup.SqlServerConnectionString);
    }
}