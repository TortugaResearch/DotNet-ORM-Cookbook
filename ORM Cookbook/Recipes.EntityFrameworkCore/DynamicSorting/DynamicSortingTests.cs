using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.DynamicSorting;

namespace Recipes.EntityFrameworkCore.DynamicSorting
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
