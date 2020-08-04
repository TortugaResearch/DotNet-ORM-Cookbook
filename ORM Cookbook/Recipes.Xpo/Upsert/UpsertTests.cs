using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.Upsert;

namespace Recipes.Xpo.Upsert
{
    [TestClass]
    public class UpsertTests : UpsertTests<Division>
    {
        protected override IUpsertScenario<Division> GetScenario()
        {
            return new UpsertScenario();
        }
    }
}
