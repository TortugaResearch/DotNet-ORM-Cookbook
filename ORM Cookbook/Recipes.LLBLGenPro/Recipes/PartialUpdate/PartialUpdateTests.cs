using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.PartialUpdate;

namespace Recipes.LLBLGenPro.PartialUpdate
{
    [TestClass]
    public class PartialUpdateTests : PartialUpdateTests<EmployeeClassificationEntity>
    {
        protected override IPartialUpdateScenario<EmployeeClassificationEntity> GetScenario()
        {
            return new PartialUpdateScenario();
        }
    }
}
