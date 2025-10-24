using Recipes.ModelWithLookup;
using Recipes.RepoDb.Models;

namespace Recipes.RepoDB.ModelWithLookup;

[TestClass]
public class ModelWithLookupComplexTests : ModelWithLookupComplexTests<EmployeeComplex>
{
    protected override IModelWithLookupComplexScenario<EmployeeComplex> GetScenario()
    {
        return new ModelWithLookupComplexScenario(Setup.ConnectionString);
    }
}