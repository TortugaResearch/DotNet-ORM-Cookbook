using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.Sorting;

namespace Recipes.EntityFrameworkCore.Sorting
{
    [TestClass]
    public class SortingTests : SortingTests<Employee>
    {
        protected override ISortingRepository<Employee> GetRepository()
        {
            return new SortingRepository(Setup.DBContextFactory);
        }
    }
}
