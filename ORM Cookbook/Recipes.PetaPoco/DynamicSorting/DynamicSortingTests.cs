using Recipes.PetaPoco.Models;
using Recipes.DynamicSorting;

namespace Recipes.PetaPoco.DynamicSorting;

[TestClass]
public class DynamicSortingTests : DynamicSortingTests<EmployeeSimple>
{
    protected override IDynamicSortingScenario<EmployeeSimple> GetScenario()
    {
        return new DynamicSortingScenario(Setup.SqlServerConnectionString);
    }
}