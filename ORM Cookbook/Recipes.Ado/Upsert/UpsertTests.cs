using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Ado.Models;
using Recipes.Upsert;

namespace Recipes.Ado.Upsert
{
    [TestClass]
    public class UpsertTests : UpsertTests<Division>
    {
        protected override IUpsertScenario<Division> GetScenario()
        {
            return new UpsertScenario(Setup.SqlServerConnectionString);
        }
    }
}
