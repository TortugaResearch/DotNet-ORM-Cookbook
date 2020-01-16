using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ModelWithLookup;
using Recipes.RepoDb.Entities;

namespace Recipes.RepoDb.ModelWithLookup
{
    [TestClass]
    public class ModelWithLookupSimpleTests : ModelWithLookupSimpleTests<EmployeeSimple>
    {
        protected override IModelWithLookupSimpleScenario<EmployeeSimple> GetScenario()
        {
            return new ModelWithLookupSimpleScenario(Setup.ConnectionString);
        }
    }
}
