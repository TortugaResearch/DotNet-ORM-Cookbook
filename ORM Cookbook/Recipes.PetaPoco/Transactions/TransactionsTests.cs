using Recipes.PetaPoco.Models;
using Recipes.Transactions;

namespace Recipes.PetaPoco.Transactions;

[TestClass]
public class TransactionsTests : TransactionsTests<EmployeeClassification>
{
    protected override ITransactionsScenario<EmployeeClassification> GetScenario()
    {
        return new TransactionsScenario(Setup.SqlServerConnectionString);
    }
}