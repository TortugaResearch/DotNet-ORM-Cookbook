using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.SingleModelCrudAsync;

namespace Recipes.LLBLGenPro.SingleModelCrudAsync
{
    [TestClass]
    public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassificationEntity>
    {
        protected override ISingleModelCrudAsyncRepository<EmployeeClassificationEntity> GetRepository()
        {
            return new SingleModelCrudAsyncRepository();
        }
    }
}
