using Recipes.Dapper.Models;
using Recipes.Upsert;

namespace Recipes.Dapper.Upsert;

[TestClass]
public class UpsertTests : UpsertTests<Division>
{
    protected override IUpsertScenario<Division> GetScenario()
    {
        return new UpsertScenario(Setup.SqlServerConnectionString);
    }
}