using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using Recipes.Transactions;

namespace Recipes.Xpo.Transactions
{
    [TestClass]
    public class TransactionsTests : TransactionsTests<EmployeeClassification>
    {
        protected override ITransactionsScenario<EmployeeClassification> GetScenario()
        {
            return new TransactionsScenario();
        }
    }
}
