using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LLBLGenPro.ModelWithLookup;
using Recipes.ModelWithLookup;

namespace Recipes.LLBLGenPro.ModelWithLookup
{
    [TestClass]
    public class ModelWithLookupComplexTests : ModelWithLookupComplexTests<EmployeeEntity>
    {
        protected override IModelWithLookupComplexScenario<EmployeeEntity> GetScenario()
        {
            return new ModelWithLookupComplexScenario();
        }
    }
}
