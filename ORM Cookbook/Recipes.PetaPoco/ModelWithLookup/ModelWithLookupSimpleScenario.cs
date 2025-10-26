using Recipes.ModelWithLookup;
using Recipes.PetaPoco.Models;

namespace Recipes.PetaPoco.ModelWithLookup;

public class ModelWithLookupSimpleScenario : ScenarioBase, IModelWithLookupSimpleScenario<EmployeeSimple>
{
    public ModelWithLookupSimpleScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        throw new NotImplementedException();
    }

    public void Delete(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        throw new NotImplementedException();
    }

    public void DeleteByKey(int employeeKey)
    {
        throw new NotImplementedException();
    }

    public IList<EmployeeSimple> FindByLastName(string lastName)
    {
        throw new NotImplementedException();
    }

    public IList<EmployeeSimple> GetAll()
    {
        throw new NotImplementedException();
    }

    public EmployeeSimple? GetByKey(int employeeKey)
    {
        throw new NotImplementedException();
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }

    public void Update(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        throw new NotImplementedException();
    }
}