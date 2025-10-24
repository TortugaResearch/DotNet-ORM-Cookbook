using Recipes.EntityFramework.Entities;
using Recipes.Transactions;

namespace Recipes.EntityFramework.Transactions;

[TestClass]
public class TransactionsTests : TransactionsTests<EmployeeClassification>
{
    protected override ITransactionsScenario<EmployeeClassification> GetScenario()
    {
        return new TransactionsScenario(Setup.DBContextFactory);
    }
}