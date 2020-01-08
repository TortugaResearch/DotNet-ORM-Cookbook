using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.SingleModelCrud;

namespace Recipes.LLBLGenPro.SingleModelCrud
{
    [TestClass]
    public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassificationEntity>
    {
        protected override ISingleModelCrudRepository<EmployeeClassificationEntity> GetRepository()
        {
            return new SingleModelCrudRepository();
        }
    }
}
