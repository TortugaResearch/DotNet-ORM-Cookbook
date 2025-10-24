using Recipes.ServiceStack.Entities;
using Recipes.Upsert;

namespace Recipes.ServiceStack.Upsert;

[TestClass]
public class UpsertTests : UpsertTests<Division>
{
    protected override IUpsertScenario<Division> GetScenario()
    {
        return new UpsertScenario(Setup.DbConnectionFactory);
    }
}