using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ServiceStack.Entities;
using Recipes.TryCrud;

namespace Recipes.ServiceStack.TryCrud
{
    [TestClass]
    public class TryCrudTests : TryCrudTests<EmployeeClassification>
    {
        protected override ITryCrudRepository<EmployeeClassification> GetRepository()
        {
            return new TryCrudRepository(Setup.DbConnectionFactory);
        }
    }
}