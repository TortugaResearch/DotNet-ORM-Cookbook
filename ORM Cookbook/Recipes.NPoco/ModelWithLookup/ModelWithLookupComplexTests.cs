using Recipes.NPoco.Models;
using Recipes.ModelWithLookup;

namespace Recipes.NPoco.ModelWithLookup;

[TestClass]
public class ModelWithLookupComplexTests : ModelWithLookupComplexTests<EmployeeComplex>
{
    protected override IModelWithLookupComplexScenario<EmployeeComplex> GetScenario()
    {
        return new ModelWithLookupComplexScenario(Setup.SqlServerConnectionString);
    }
}