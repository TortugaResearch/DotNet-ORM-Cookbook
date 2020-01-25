using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.MultipleCrud;

namespace Recipes.LLBLGenPro.MultipleCrud
{
    [TestClass]
    public class MultipleCrudTests : MultipleCrudTests<EmployeeEntity>
    {
        protected override IMultipleCrudScenario<EmployeeEntity> GetScenario()
        {
            return new MultipleCrudScenario();
        }
    }
}
