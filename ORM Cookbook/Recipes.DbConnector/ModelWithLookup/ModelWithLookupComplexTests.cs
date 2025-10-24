using Recipes.DbConnector.Models;
using Recipes.ModelWithLookup;

namespace Recipes.DbConnector.ModelWithLookup;

[TestClass]
public class ModelWithLookupComplexTests : ModelWithLookupComplexTests<EmployeeComplex>
{
    protected override IModelWithLookupComplexScenario<EmployeeComplex> GetScenario()
    {
        return new ModelWithLookupComplexScenario(Setup.SqlServerConnectionString);
    }
}