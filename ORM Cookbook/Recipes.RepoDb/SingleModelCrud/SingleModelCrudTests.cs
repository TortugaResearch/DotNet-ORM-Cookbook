using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Entities;
using Recipes.SingleModelCrud;

namespace Recipes.RepoDb.SingleModelCrud
{
    [TestClass]
    public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassificationSingleModelCrud>
    {
        protected override ISingleModelCrudScenario<EmployeeClassificationSingleModelCrud> GetScenario()
        {
            return new SingleModelCrudScenario(Setup.ConnectionString);
        }
    }
}
