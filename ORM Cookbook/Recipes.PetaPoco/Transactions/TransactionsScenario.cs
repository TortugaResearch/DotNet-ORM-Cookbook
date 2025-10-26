using Recipes.PetaPoco.Models;
using Recipes.Transactions;
using System.Data;

namespace Recipes.PetaPoco.Transactions;

public class TransactionsScenario : ScenarioBase, ITransactionsScenario<EmployeeClassification>
{
    public TransactionsScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(EmployeeClassification classification, bool shouldRollBack)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }

    public int CreateWithIsolationLevel(EmployeeClassification classification, bool shouldRollBack, IsolationLevel isolationLevel)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }
}