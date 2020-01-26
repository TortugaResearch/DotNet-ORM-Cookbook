using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.BulkInsert;
using Recipes.Chain.Models;

namespace Recipes.Chain.BulkInsert
{
    [TestClass]
    public class BulkInsertTests : BulkInsertTests<EmployeeSimple>
    {
        protected override IBulkInsertScenario<EmployeeSimple> GetScenario()
        {
            return new BulkInsertScenario(Setup.PrimaryDataSource);
        }
    }
}
