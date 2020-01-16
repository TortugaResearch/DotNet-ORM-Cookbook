using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.TryCrud;

namespace Recipes.LLBLGenPro.TryCrud
{
    [TestClass]
    public class TryCrudTests : TryCrudTests<EmployeeClassificationEntity>
    {
        protected override ITryCrudScenario<EmployeeClassificationEntity> GetScenario()
        {
            return new TryCrudScenario();
        }
    }
}
