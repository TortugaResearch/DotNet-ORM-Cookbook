using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LinqToDB.Entities;
using Recipes.DynamicSorting;

namespace Recipes.LinqToDB.DynamicSorting
{
    [TestClass]
    public class DynamicSortingTests : DynamicSortingTests<Employee>
    {
        protected override IDynamicSortingScenario<Employee> GetScenario()
        {
            return new DynamicSortingScenario();
        }
    }
}
