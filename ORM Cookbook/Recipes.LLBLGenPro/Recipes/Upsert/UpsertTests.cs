using LLBLGenPro.OrmCookbook.EntityClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Upsert;

namespace Recipes.LLBLGenPro.Upsert
{
    [TestClass]
    public class UpsertTests : UpsertTests<DivisionEntity>
    {
        protected override IUpsertScenario<DivisionEntity> GetScenario()
        {
            return new UpsertScenario();
        }
    }
}
