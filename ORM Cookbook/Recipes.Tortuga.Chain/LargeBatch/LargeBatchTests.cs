using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Chain.Models;
using Recipes.LargeBatch;

namespace Recipes.Chain.LargeBatch
{
    [TestClass]
    public class LargeBatchTests : LargeBatchTests<EmployeeSimple>
    {
        protected override ILargeBatchScenario<EmployeeSimple> GetScenario()
        {
            return new LargeBatchScenario(Setup.PrimaryDataSource);
        }
    }
}
