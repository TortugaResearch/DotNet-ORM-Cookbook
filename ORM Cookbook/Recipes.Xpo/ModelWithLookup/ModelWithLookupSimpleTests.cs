using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.ModelWithLookup;

namespace Recipes.Xpo.ModelWithLookup
{
    [TestClass]
    public class ModelWithLookupSimpleTests : ModelWithLookupSimpleTests<Employee>
    {
        protected override IModelWithLookupSimpleScenario<Employee> GetScenario()
        {
            return new ModelWithLookupSimpleScenario();
        }
    }
}
