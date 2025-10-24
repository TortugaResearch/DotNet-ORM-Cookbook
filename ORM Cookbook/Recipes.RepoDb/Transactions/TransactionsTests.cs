using Recipes.RepoDB.Models;
using Recipes.Transactions;

namespace Recipes.RepoDB.Transactions;

[TestClass]
public class TransactionsTests : TransactionsTests<EmployeeClassification>
{
    protected override ITransactionsScenario<EmployeeClassification> GetScenario()
    {
        return new TransactionsScenario(Setup.ConnectionString);
    }
}