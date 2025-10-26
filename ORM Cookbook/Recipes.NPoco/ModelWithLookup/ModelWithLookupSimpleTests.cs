using Recipes.NPoco.Models;
using Recipes.ModelWithLookup;

namespace Recipes.NPoco.ModelWithLookup;

[TestClass]
public class ModelWithLookupSimpleTests : ModelWithLookupSimpleTests<EmployeeSimple>
{
    protected override IModelWithLookupSimpleScenario<EmployeeSimple> GetScenario()
    {
        return new ModelWithLookupSimpleScenario(Setup.SqlServerConnectionString);
    }
}