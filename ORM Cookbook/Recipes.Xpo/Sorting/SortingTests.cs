using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.Sorting;

namespace Recipes.Xpo.Sorting
{
    [TestClass]
    public class SortingTests : SortingTests<Employee>
    {
        protected override ISortingScenario<Employee> GetScenario()
        {
            return new SortingScenario();
        }
    }
}
