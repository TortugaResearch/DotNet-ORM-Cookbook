using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LinqToDB.Entities;
using Recipes.Upsert;

namespace Recipes.LinqToDB.Upsert
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
