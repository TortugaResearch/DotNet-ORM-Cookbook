using Recipes.PetaPoco.Models;
using Recipes.Sorting;

namespace Recipes.PetaPoco.Sorting;

[TestClass]
public class SortingTests : SortingTests<EmployeeSimple>
{
    protected override ISortingScenario<EmployeeSimple> GetScenario()
    {
        return new SortingScenario(Setup.SqlServerConnectionString);
    }
}