using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.SingleModelCrud;

namespace Recipes.Dapper.SingleModelCrud
{
    [TestClass]
    public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
    {
        protected override ISingleModelCrudRepository<EmployeeClassification> GetRepository()
        {
            return new SingleModelCrudRepository(Setup.ConnectionString);
        }
    }
}
