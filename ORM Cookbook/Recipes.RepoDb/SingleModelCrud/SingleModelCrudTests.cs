using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.RepoDb.Models;
using Recipes.SingleModelCrud;

namespace Recipes.RepoDb.SingleModelCrud
{
    [TestClass]
    public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
    {
        protected override ISingleModelCrudScenario<EmployeeClassification> GetScenario()
        {
            return new SingleModelCrudScenario(Setup.ConnectionString);
        }
    }
}
