using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.EntityFrameworkCore.Entities;
using Recipes.SingleModelCrud;

namespace Recipes.EntityFrameworkCore.SingleModelCrud
{
    [TestClass]
    public class SingleModelCrudTests2 : SingleModelCrudTests<EmployeeClassification>
    {
        protected override ISingleModelCrudRepository<EmployeeClassification> GetRepository()
        {
            return new SingleModelCrudRepository2(Setup.DBContextFactory);
        }
    }
}
