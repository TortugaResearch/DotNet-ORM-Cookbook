using Recipes.ModelWithLookup;
using Recipes.RepoDB.Models;

namespace Recipes.RepoDB.ModelWithLookup;

[TestClass]
public class ModelWithLookupSimpleTests : ModelWithLookupSimpleTests<EmployeeSimple>
{
    protected override IModelWithLookupSimpleScenario<EmployeeSimple> GetScenario()
    {
        return new ModelWithLookupSimpleScenario(Setup.ConnectionString);
    }
}