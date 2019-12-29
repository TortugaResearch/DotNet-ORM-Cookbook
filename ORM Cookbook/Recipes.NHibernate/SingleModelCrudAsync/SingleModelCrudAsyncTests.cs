using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.NHibernate.Models;
using Recipes.SingleModelCrudAsync;

namespace Recipes.NHibernate.SingleModelCrudAsync
{
    [TestClass]
    public class SingleModelCrudAsyncTests : SingleModelCrudAsyncTests<EmployeeClassification>
    {
        protected override ISingleModelCrudAsyncRepository<EmployeeClassification> GetRepository()
        {
            return new SingleModelCrudAsyncRepository(Setup.SessionFactory);
        }
    }
}
