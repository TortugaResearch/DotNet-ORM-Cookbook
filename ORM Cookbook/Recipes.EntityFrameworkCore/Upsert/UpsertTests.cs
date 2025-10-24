using Recipes.EntityFrameworkCore.Entities;
using Recipes.Upsert;

namespace Recipes.EntityFrameworkCore.Upsert
{
    [TestClass]
    public class UpsertTests : UpsertTests<Division>
    {
        protected override IUpsertScenario<Division> GetScenario()
        {
            return new UpsertScenario(Setup.DBContextFactory);
        }
    }
}