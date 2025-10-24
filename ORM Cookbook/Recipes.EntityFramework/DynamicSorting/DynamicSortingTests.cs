using Recipes.DynamicSorting;
using Recipes.EntityFramework.Entities;

namespace Recipes.EntityFramework.DynamicSorting;

[TestClass]
public class DynamicSortingTests : DynamicSortingTests<Employee>
{
    protected override IDynamicSortingScenario<Employee> GetScenario()
    {
        return new DynamicSortingScenario(Setup.DBContextFactory);
    }
}