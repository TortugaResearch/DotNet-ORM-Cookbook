using Recipes.EntityFramework.Entities;
using Recipes.Upsert;

namespace Recipes.EntityFramework.Upsert;

[TestClass]
public class UpsertTests : UpsertTests<Division>
{
    protected override IUpsertScenario<Division> GetScenario()
    {
        return new UpsertScenario(Setup.DBContextFactory);
    }
}