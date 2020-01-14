using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ServiceStack.Entities;
using Recipes.Sorting;

namespace Recipes.ServiceStack.Sorting
{
    [TestClass]
    public class SortingTests : SortingTests<Employee>
    {
        protected override ISortingRepository<Employee> GetRepository()
        {
            return new SortingRepository(Setup.DbConnectionFactory);
        }
    }
}
