using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LargeBatch;
using Recipes.RepoDb.Models;

namespace Recipes.RepoDb.LargeBatch
{
    [TestClass]
    public class LargeBatchTests : LargeBatchTests<EmployeeSimple>
    {
        protected override ILargeBatchScenario<EmployeeSimple> GetScenario()
        {
            return new LargeBatchScenario(Setup.ConnectionString);
        }
    }
}
