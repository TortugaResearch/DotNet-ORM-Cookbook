using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.SingleModelCrud;

namespace Recipes.Ado.SingleModelCrud
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
