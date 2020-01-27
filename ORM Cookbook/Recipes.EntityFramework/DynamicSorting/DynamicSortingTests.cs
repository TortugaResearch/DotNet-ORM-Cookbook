using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFramework.Entities;
using Recipes.DynamicSorting;

namespace Recipes.EntityFramework.DynamicSorting
{
    [TestClass]
    public class DynamicSortingTests : DynamicSortingTests<Employee>
    {
        protected override IDynamicSortingScenario<Employee> GetScenario()
        {
            return new DynamicSortingScenario(Setup.DBContextFactory);
        }
    }
}
