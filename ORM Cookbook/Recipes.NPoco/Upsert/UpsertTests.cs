using Recipes.NPoco.Models;
using Recipes.Upsert;

namespace Recipes.NPoco.Upsert;

[TestClass]
public class UpsertTests : UpsertTests<Division>
{
    protected override IUpsertScenario<Division> GetScenario()
    {
        return new UpsertScenario(Setup.SqlServerConnectionString);
    }
}