using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LargeBatch;
using Recipes.ServiceStack.Entities;

namespace Recipes.ServiceStack.LargeBatch
{
    [TestClass]
    public class LargeBatchTests : LargeBatchTests<Employee>
    {
        protected override ILargeBatchScenario<Employee> GetScenario()
        {
            return new LargeBatchScenario(Setup.DbConnectionFactory);
        }
    }
}
