using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Sorting;

namespace Recipes.Ado.Sorting
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
