using Recipes.PetaPoco.Models;
using Recipes.SingleModelCrud;

namespace Recipes.PetaPoco.SingleModelCrud;

public class SingleModelCrudScenario : ScenarioBase, ISingleModelCrudScenario<EmployeeClassification>
{
    public SingleModelCrudScenario(string connectionString) : base(connectionString)
    {
    }

    virtual public int Create(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }

    virtual public void Delete(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }

    public void DeleteByKey(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }

    public EmployeeClassification? FindByName(string employeeClassificationName)
    {
        throw new NotImplementedException();
    }

    virtual public IList<EmployeeClassification> GetAll()
    {
        throw new NotImplementedException();
    }

    virtual public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }

    virtual public void Update(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        throw new NotImplementedException();
    }
}