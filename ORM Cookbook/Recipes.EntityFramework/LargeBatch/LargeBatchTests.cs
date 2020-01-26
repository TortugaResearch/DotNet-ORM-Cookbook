using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFramework.Entities;
using Recipes.LargeBatch;

namespace Recipes.EntityFramework.LargeBatch
{
    [TestClass]
    public class LargeBatchTests : LargeBatchTests<Employee>
    {
        protected override ILargeBatchScenario<Employee> GetScenario()
        {
            return new LargeBatchScenario(Setup.DBContextFactory);
        }
    }
}
