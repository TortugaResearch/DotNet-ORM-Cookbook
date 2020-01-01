using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.NHibernate.Entities;
using Recipes.SingleModelCrud;

namespace Recipes.NHibernate.SingleModelCrud
{
    [TestClass]
    public class SingleModelCrudTests : SingleModelCrudTests<EmployeeClassification>
    {
        protected override ISingleModelCrudRepository<EmployeeClassification> GetRepository()
        {
            return new SingleModelCrudRepository(Setup.SessionFactory);
        }
    }
}
