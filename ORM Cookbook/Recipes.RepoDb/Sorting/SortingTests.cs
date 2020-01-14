using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Entities;
using Recipes.Sorting;

namespace Recipes.RepoDb.Sorting
{
    [TestClass]
    public class SortingTests : SortingTests<EmployeeSimple>
    {
        protected override ISortingRepository<EmployeeSimple> GetRepository()
        {
            return new SortingRepository(Setup.ConnectionString);
        }
    }
}
