using Recipes.ModelWithLookup;
using Recipes.ServiceStack.Entities;

namespace Recipes.ServiceStack.ModelWithLookup;

[TestClass]
public class ModelWithLookupComplexTests : ModelWithLookupComplexTests<Employee>
{
    protected override IModelWithLookupComplexScenario<Employee> GetScenario()
    {
        return new ModelWithLookupComplexScenario(Setup.DbConnectionFactory);
    }
}