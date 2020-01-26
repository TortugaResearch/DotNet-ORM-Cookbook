using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Dapper.Models;
using Recipes.LargeBatch;

namespace Recipes.Dapper.LargeBatch
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
