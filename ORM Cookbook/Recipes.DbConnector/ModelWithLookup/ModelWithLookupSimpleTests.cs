using Recipes.DbConnector.Models;
using Recipes.ModelWithLookup;

namespace Recipes.DbConnector.ModelWithLookup;

[TestClass]
public class ModelWithLookupSimpleTests : ModelWithLookupSimpleTests<EmployeeSimple>
{
    protected override IModelWithLookupSimpleScenario<EmployeeSimple> GetScenario()
    {
        return new ModelWithLookupSimpleScenario(Setup.SqlServerConnectionString);
    }
}