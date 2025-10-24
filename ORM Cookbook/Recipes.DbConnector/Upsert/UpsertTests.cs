using Recipes.DbConnector.Models;
using Recipes.Upsert;

namespace Recipes.DbConnector.Upsert;

[TestClass]
public class UpsertTests : UpsertTests<Division>
{
    protected override IUpsertScenario<Division> GetScenario()
    {
        return new UpsertScenario(Setup.SqlServerConnectionString);
    }
}