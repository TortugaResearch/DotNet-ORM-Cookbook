using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.PartialUpdate;

namespace Recipes.Xpo.PartialUpdate
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
