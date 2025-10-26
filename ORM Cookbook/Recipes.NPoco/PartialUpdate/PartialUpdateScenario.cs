using Recipes.NPoco.Models;
using Recipes.PartialUpdate;

namespace Recipes.NPoco.PartialUpdate;

public class PartialUpdateScenario : ScenarioBase, IPartialUpdateScenario<EmployeeClassification>
{
    public PartialUpdateScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }

    public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
    {
        if (updateMessage == null)
            throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

        throw new NotImplementedException();
    }

    public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
    {
        if (updateMessage == null)
            throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

        throw new NotImplementedException();
    }

    public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
    {
        throw new NotImplementedException();
    }
}