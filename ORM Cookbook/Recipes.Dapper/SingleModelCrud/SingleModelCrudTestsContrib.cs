using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Dapper.Models;
using Recipes.SingleModelCrud;

namespace Recipes.Dapper.SingleModelCrud
{
    [TestClass]
    public class SingleModelCrudTestsContrib : SingleModelCrudTests<EmployeeClassification>
    {
        protected override ISingleModelCrudScenario<EmployeeClassification> GetScenario()
        {
            return new SingleModelCrudScenarioContrib(Setup.ConnectionString);
        }
    }
}
