using Recipes.Chain.Models;
using Recipes.Upsert;

namespace Recipes.Chain.Upsert
{
    [TestClass]
    public class UpsertTests : UpsertTests<Division>
    {
        protected override IUpsertScenario<Division> GetScenario()
        {
            return new UpsertScenario(Setup.PrimaryDataSource);
        }
    }
}