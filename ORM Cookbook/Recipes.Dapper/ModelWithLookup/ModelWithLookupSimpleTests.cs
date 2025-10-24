using Recipes.Dapper.Models;
using Recipes.ModelWithLookup;

namespace Recipes.Dapper.ModelWithLookup;

[TestClass]
public class ModelWithLookupSimpleTests : ModelWithLookupSimpleTests<EmployeeSimple>
{
    protected override IModelWithLookupSimpleScenario<EmployeeSimple> GetScenario()
    {
        return new ModelWithLookupSimpleScenario(Setup.SqlServerConnectionString);
    }
}