using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ServiceStack.Entities;
using Recipes.SingleModelCrudAsync;

namespace Recipes.ServiceStack.SingleModelCrudAsync
{
    [TestClass]
    public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
    {
        protected override ISingleModelCrudAsyncRepository<EmployeeClassification> GetRepository()
        {
            return new SingleModelCrudAsyncRepository(Setup.DbConnectionFactory);
        }
    }
}