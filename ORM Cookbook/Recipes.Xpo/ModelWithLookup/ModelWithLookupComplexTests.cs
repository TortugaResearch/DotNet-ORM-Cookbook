using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.ModelWithLookup;

namespace Recipes.Xpo.ModelWithLookup
{
    [TestClass]
    public class ModelWithLookupComplexTests : ModelWithLookupComplexTests<Employee>
    {
        protected override IModelWithLookupComplexScenario<Employee> GetScenario()
        {
            return new ModelWithLookupComplexScenario();
        }
    }
}
