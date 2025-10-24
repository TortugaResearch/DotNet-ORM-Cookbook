using Recipes.Ado.Models;
using Recipes.ModelWithLookup;

namespace Recipes.Ado.ModelWithLookup;

[TestClass]
public class ModelWithLookupSimpleTests : ModelWithLookupSimpleTests<EmployeeSimple>
{
    protected override IModelWithLookupSimpleScenario<EmployeeSimple> GetScenario()
    {
        return new ModelWithLookupSimpleScenario(Setup.SqlServerConnectionString);
    }
}