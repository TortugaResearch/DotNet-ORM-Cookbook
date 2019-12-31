using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.PartialUpdate;
using Recipes.ServiceStack.Entities;

namespace Recipes.ServiceStack.PartialUpdate
{
    [TestClass]
    public class PartialUpdateTests : PartialUpdateTests<EmployeeClassificationPartial>
    {
        protected override IPartialUpdateRepository<EmployeeClassificationPartial> GetRepository()
        {
            return new PartialUpdateRepository(Setup.DbConnectionFactory);
        }
    }
}