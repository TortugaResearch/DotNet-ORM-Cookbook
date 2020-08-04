using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.LargeBatch;

namespace Recipes.Xpo.LargeBatch
{
    [TestClass]
    public class LargeBatchTests : LargeBatchTests<Employee>
    {
        protected override ILargeBatchScenario<Employee> GetScenario()
        {
            return new LargeBatchScenario();
        }
    }
}
