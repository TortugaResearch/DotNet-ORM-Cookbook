using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Entities;
using Recipes.TryCrud;

namespace Recipes.RepoDb.TryCrud
{
    [TestClass]
    public class TryCrudTests : TryCrudTests<EmployeeClassificationTryCrud>
    {
        protected override ITryCrudScenario<EmployeeClassificationTryCrud> GetScenario()
        {
            return new TryCrudScenario(Setup.ConnectionString);
        }
    }
}
