using Recipes.EntityFrameworkCore.Entities;
using Recipes.Sorting;

namespace Recipes.EntityFrameworkCore.Sorting
{
    [TestClass]
    public class SortingTests : SortingTests<Employee>
    {
        protected override ISortingScenario<Employee> GetScenario()
        {
            return new SortingScenario(Setup.DBContextFactory);
        }
    }
}