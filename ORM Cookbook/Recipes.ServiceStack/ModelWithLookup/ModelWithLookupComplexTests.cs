using Recipes.ServiceStack.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ModelWithLookup;

namespace Recipes.ServiceStack.ModelWithLookup
{
    [TestClass]
    public class ModelWithLookupComplexTests : ModelWithLookupComplexTests<Employee>
    {
        protected override IModelWithLookupComplexScenario<Employee> GetScenario()
        {
            return new ModelWithLookupComplexScenario(Setup.DbConnectionFactory);
        }
    }
}
