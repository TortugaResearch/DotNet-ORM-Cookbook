using Recipes.PetaPoco.Models;
using Recipes.Views;

namespace Recipes.PetaPoco.Views;

public class ViewsScenario : ScenarioBase, IViewsScenario<EmployeeDetail, EmployeeSimple>
{
    public ViewsScenario(string connectionString) : base(connectionString)
    {
    }

    public int Create(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        throw new NotImplementedException();
    }

    public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }

    public IList<EmployeeDetail> FindByLastName(string lastName)
    {
        throw new NotImplementedException();
    }

    public EmployeeDetail? GetByEmployeeKey(int employeeKey)
    {
        throw new NotImplementedException();
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        throw new NotImplementedException();
    }
}