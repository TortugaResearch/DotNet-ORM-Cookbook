using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ServiceStack.Entities;
using Recipes.DynamicSorting;

namespace Recipes.ServiceStack.DynamicSorting
{
    [TestClass]
    public class DynamicSortingTests : DynamicSortingTests<Employee>
    {
        protected override IDynamicSortingScenario<Employee> GetScenario()
        {
            return new DynamicSortingScenario(Setup.DbConnectionFactory);
        }
    }
}
