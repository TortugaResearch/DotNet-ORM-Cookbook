using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.DynamicSorting;

namespace Recipes.Xpo.DynamicSorting
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
