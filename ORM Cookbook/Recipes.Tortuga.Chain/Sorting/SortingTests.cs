using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Sorting;

namespace Recipes.Chain.Sorting
{
    [TestClass]
    public class SortingTests : SortingTests<EmployeeSimple>
    {
        protected override ISortingRepository<EmployeeSimple> GetRepository()
        {
            return new SortingRepository(Setup.PrimaryDataSource);
        }
    }
}
