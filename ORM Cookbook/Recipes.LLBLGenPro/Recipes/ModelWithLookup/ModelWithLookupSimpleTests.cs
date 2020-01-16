using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ModelWithLookup;

namespace Recipes.LLBLGenPro.ModelWithLookup
{
    [TestClass]
    public class ModelWithLookupSimpleTests : ModelWithLookupSimpleTests<EmployeeEntity>
    {
        protected override IModelWithLookupSimpleScenario<EmployeeEntity> GetScenario()
        {
            return new ModelWithLookupSimpleScenario();
        }
    }
}
