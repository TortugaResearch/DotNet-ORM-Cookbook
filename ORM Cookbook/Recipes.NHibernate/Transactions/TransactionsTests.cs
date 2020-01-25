using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.NHibernate.Entities;
using Recipes.Transactions;

namespace Recipes.NHibernate.Transactions
{
    [TestClass]
    public class TransactionsTests : TransactionsTests<EmployeeClassification>
    {
        protected override ITransactionsScenario<EmployeeClassification> GetScenario()
        {
            return new TransactionsScenario(Setup.SessionFactory);
        }
    }
}
