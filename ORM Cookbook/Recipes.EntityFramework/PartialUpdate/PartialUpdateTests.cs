using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFramework.Entities;
using Recipes.PartialUpdate;

namespace Recipes.EntityFramework.PartialUpdate
{
    [TestClass]
    public class PartialUpdateTests : PartialUpdateTests<EmployeeClassification>
    {
        protected override IPartialUpdateScenario<EmployeeClassification> GetScenario()
        {
            return new PartialUpdateScenario(Setup.DBContextFactory);
        }
    }
}
