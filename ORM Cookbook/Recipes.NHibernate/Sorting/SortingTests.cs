using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.NHibernate.Entities;
using Recipes.Sorting;

namespace Recipes.NHibernate.Sorting
{
    [TestClass]
    public class SortingTests : SortingTests<Employee>
    {
        protected override ISortingRepository<Employee> GetRepository()
        {
            return new SortingRepository(Setup.SessionFactory);
        }
    }
}
