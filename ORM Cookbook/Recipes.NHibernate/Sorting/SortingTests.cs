using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.NHibernate.Entities;
using Recipes.Sorting;

namespace Recipes.NHibernate.Sorting
{
    [TestClass]
    public class SortingTests : SortingTests<Employee>
    {
        protected override ISortingScenario<Employee> GetScenario()
        {
            return new SortingScenario(Setup.SessionFactory);
        }
    }
}
