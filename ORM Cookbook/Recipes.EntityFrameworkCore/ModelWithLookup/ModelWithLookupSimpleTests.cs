using Recipes.EntityFrameworkCore.Entities;
using Recipes.ModelWithLookup;

namespace Recipes.EntityFrameworkCore.ModelWithLookup;

[TestClass]
public class ModelWithLookupSimpleTests : ModelWithLookupSimpleTests<Employee>
{
    protected override IModelWithLookupSimpleScenario<Employee> GetScenario()
    {
        return new ModelWithLookupSimpleScenario(Setup.DBContextFactory);
    }
}