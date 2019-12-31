using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ServiceStack.Entities;
using Recipes.SingleModelCrud;

namespace Recipes.ServiceStack.SingleModelCrud
{
    [TestClass]
    public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
    {
        protected override ISingleModelCrudRepository<EmployeeClassification> GetRepository()
        {
            return new SingleModelCrudRepository(Setup.DbConnectionFactory);
        }
    }
}