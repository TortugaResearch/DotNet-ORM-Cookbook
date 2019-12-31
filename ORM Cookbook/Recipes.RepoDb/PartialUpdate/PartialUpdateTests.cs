using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.PartialUpdate;

namespace Recipes.RepoDb.PartialUpdate
{
    [TestClass]
    public class PartialUpdateTests : PartialUpdateTests<EmployeeClassification>
    {
        protected override IPartialUpdateRepository<EmployeeClassification> GetRepository()
        {
            throw new AssertInconclusiveException("TODO");
        }
    }
}
