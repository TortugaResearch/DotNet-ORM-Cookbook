using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.PartialUpdate;

namespace Recipes.LLBLGenPro.PartialUpdate
{
    [TestClass]
    public class PartialUpdateTests : PartialUpdateTests<EmployeeClassificationEntity>
    {
        protected override IPartialUpdateRepository<EmployeeClassificationEntity> GetRepository()
        {
            return new PartialUpdateRepository();
        }
    }
}
