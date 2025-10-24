using Recipes.DynamicSorting;
using Recipes.EntityFrameworkCore.Entities;

namespace Recipes.EntityFrameworkCore.DynamicSorting;

[TestClass]
public class DynamicSortingTests : DynamicSortingTests<Employee>
{
    protected override IDynamicSortingScenario<Employee> GetScenario()
    {
        return new DynamicSortingScenario(Setup.DBContextFactory);
    }
}