using Recipes.ModelWithLookup;
using Recipes.PetaPoco.Models;

namespace Recipes.PetaPoco.ModelWithLookup;

public class ModelWithLookupComplexScenario : ScenarioBase, IModelWithLookupComplexScenario<EmployeeComplex>
{
    public ModelWithLookupComplexScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(EmployeeComplex employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
        if (employee.EmployeeClassification == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassification)} is null.");

        throw new NotImplementedException();
    }

    public void Delete(EmployeeComplex employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        throw new NotImplementedException();
    }

    public void DeleteByKey(int employeeKey)
    {
        throw new NotImplementedException();
    }

    public IList<EmployeeComplex> FindByLastName(string lastName)
    {
        throw new NotImplementedException();
    }

    public IList<EmployeeComplex> GetAll()
    {
        throw new NotImplementedException();
    }

    public EmployeeComplex? GetByKey(int employeeKey)
    {
        throw new NotImplementedException();
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }

    public void Update(EmployeeComplex employee)
    {
        throw new NotImplementedException();
    }
}