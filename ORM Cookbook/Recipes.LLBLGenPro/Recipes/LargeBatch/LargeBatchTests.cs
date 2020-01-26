using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LargeBatch;

namespace Recipes.LLBLGenPro.LargeBatch
{
    [TestClass]
    public class LargeBatchTests : LargeBatchTests<EmployeeEntity>
    {
        protected override ILargeBatchScenario<EmployeeEntity> GetScenario()
        {
            return new LargeBatchScenario();
        }
    }
}
