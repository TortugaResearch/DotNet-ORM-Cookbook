using Recipes.PetaPoco.Models;
using Recipes.ModelWithLookup;

namespace Recipes.PetaPoco.ModelWithLookup;

[TestClass]
public class ModelWithLookupComplexTests : ModelWithLookupComplexTests<EmployeeComplex>
{
    protected override IModelWithLookupComplexScenario<EmployeeComplex> GetScenario()
    {
        return new ModelWithLookupComplexScenario(Setup.SqlServerConnectionString);
    }
}