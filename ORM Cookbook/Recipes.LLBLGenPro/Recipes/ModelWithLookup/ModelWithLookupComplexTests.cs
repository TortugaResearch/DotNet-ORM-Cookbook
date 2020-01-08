using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LLBLGenPro.ModelWithLookup;
using Recipes.ModelWithLookup;

namespace Recipes.LLBLGenPro.ModelWithLookup
{
    [TestClass]
    public class ModelWithLookupComplexTests : ModelWithLookupComplexTests<EmployeeEntity>
    {
        protected override IModelWithLookupComplexRepository<EmployeeEntity> GetRepository()
        {
            return new ModelWithLookupComplexRepository();
        }
    }
}
