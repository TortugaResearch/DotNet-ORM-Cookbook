using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.LinqToDB.Entities;
using Recipes.PartialUpdate;

namespace Recipes.LinqToDB.PartialUpdate
{
    [TestClass]
    public class PartialUpdateTests : PartialUpdateTests<EmployeeClassification>
    {
        protected override IPartialUpdateScenario<EmployeeClassification> GetScenario()
        {
            return new PartialUpdateScenario();
        }
    }
}
