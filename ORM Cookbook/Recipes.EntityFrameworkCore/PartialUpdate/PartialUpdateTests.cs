using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.PartialUpdate;

namespace Recipes.EntityFrameworkCore.PartialUpdate
{
    [TestClass]
    public class PartialUpdateTests : PartialUpdateTests<EmployeeClassification>
    {
        protected override IPartialUpdateRepository<EmployeeClassification> GetRepository()
        {
            return new PartialUpdateRepository(Setup.DBContextFactory);
        }
    }
}
