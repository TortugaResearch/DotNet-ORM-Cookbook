using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ModelWithLookup;

namespace Recipes.Ado.ModelWithLookup
{
    [TestClass]
    public class ModelWithLookupComplexTests : ModelWithLookupComplexTests<EmployeeComplex>
    {
        protected override IModelWithLookupComplexScenario<EmployeeComplex> GetScenario()
        {
            return new ModelWithLookupComplexScenario(Setup.SqlServerConnectionString);
        }
    }
}
