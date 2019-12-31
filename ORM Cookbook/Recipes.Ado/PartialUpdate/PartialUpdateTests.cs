using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.PartialUpdate;

namespace Recipes.Ado.PartialUpdate
{
    [TestClass]
    public class PartialUpdateTests : PartialUpdateTests<EmployeeClassification>
    {
        protected override IPartialUpdateRepository<EmployeeClassification> GetRepository()
        {
            return new PartialUpdateRepository(Setup.ConnectionString);
        }
    }
}
