using Recipes.EntityFrameworkCore.Entities;
using Recipes.ModelWithLookup;

namespace Recipes.EntityFrameworkCore.ModelWithLookup;

[TestClass]
public class ModelWithLookupComplexTests : ModelWithLookupComplexTests<Employee>
{
    protected override IModelWithLookupComplexScenario<Employee> GetScenario()
    {
        return new ModelWithLookupComplexScenario(Setup.DBContextFactory);
    }
}