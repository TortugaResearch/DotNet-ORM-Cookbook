using Recipes.NPoco.Models;
using Recipes.TryCrud;

namespace Recipes.NPoco.TryCrud;

public class TryCrudScenario : ScenarioBase, ITryCrudScenario<EmployeeClassification>
{
    public TryCrudScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }

    public void DeleteByKeyOrException(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }

    public bool DeleteByKeyWithStatus(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }

    public void DeleteOrException(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }

    public bool DeleteWithStatus(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }

    public EmployeeClassification FindByNameOrException(string employeeClassificationName)
    {
        throw new NotImplementedException();
    }

    public EmployeeClassification? FindByNameOrNull(string employeeClassificationName)
    {
        throw new NotImplementedException();
    }

    public EmployeeClassification GetByKeyOrException(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }

    public EmployeeClassification? GetByKeyOrNull(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }

    public void UpdateOrException(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }

    public bool UpdateWithStatus(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }
}