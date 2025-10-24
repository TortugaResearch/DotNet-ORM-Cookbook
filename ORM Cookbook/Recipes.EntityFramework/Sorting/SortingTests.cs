using Recipes.EntityFramework.Entities;
using Recipes.Sorting;

namespace Recipes.EntityFramework.Sorting;

[TestClass]
public class SortingTests : SortingTests<Employee>
{
    protected override ISortingScenario<Employee> GetScenario()
    {
        return new SortingScenario(Setup.DBContextFactory);
    }
}