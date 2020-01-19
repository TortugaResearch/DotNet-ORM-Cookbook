using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LinqToDB.Entities;
using Recipes.Sorting;

namespace Recipes.LinqToDB.Sorting
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
