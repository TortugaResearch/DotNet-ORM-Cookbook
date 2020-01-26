using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LargeBatch;
using Recipes.LinqToDB.Entities;

namespace Recipes.LinqToDB.LargeBatch
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
