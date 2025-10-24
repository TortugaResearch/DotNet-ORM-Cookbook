using Recipes.EntityFramework.Entities;
using Recipes.ModelWithLookup;

namespace Recipes.EntityFramework.ModelWithLookup;

[TestClass]
public class ModelWithLookupSimpleTests : ModelWithLookupSimpleTests<Employee>
{
    protected override IModelWithLookupSimpleScenario<Employee> GetScenario()
    {
        return new ModelWithLookupSimpleScenario(Setup.DBContextFactory);
    }
}