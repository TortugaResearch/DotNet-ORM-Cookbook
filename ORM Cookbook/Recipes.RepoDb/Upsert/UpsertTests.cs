using Recipes.RepoDB.Models;
using Recipes.Upsert;

namespace Recipes.RepoDB.Upsert;

[TestClass]
public class UpsertTests : UpsertTests<Division>
{
    protected override IUpsertScenario<Division> GetScenario()
    {
        return new UpsertScenario(Setup.ConnectionString);
    }
}