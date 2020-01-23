using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Models;
using Recipes.Upsert;

namespace Recipes.RepoDb.Upsert
{
    [TestClass]
    public class UpsertTests : UpsertTests<Division>
    {
        protected override IUpsertScenario<Division> GetScenario()
        {
            return new UpsertScenario(Setup.ConnectionString);
        }
    }
}
