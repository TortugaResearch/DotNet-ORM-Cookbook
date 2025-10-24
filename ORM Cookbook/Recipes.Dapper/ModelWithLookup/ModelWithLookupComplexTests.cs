using Recipes.Dapper.Models;
using Recipes.ModelWithLookup;

namespace Recipes.Dapper.ModelWithLookup;

[TestClass]
public class ModelWithLookupComplexTests : ModelWithLookupComplexTests<EmployeeComplex>
{
    protected override IModelWithLookupComplexScenario<EmployeeComplex> GetScenario()
    {
        return new ModelWithLookupComplexScenario(Setup.SqlServerConnectionString);
    }
}