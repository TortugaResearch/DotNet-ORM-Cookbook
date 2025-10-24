using Recipes.ServiceStack.Entities;
using Recipes.Transactions;

namespace Recipes.ServiceStack.Transactions;

[TestClass]
public class TransactionsTests : TransactionsTests<EmployeeClassification>
{
    protected override ITransactionsScenario<EmployeeClassification> GetScenario()
    {
        return new TransactionsScenario(Setup.DbConnectionFactory);
    }
}