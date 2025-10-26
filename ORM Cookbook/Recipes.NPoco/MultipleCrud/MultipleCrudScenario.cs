using Recipes.MultipleCrud;
using Recipes.NPoco.Models;

namespace Recipes.NPoco.MultipleCrud;

public class MultipleCrudScenario : ScenarioBase, IMultipleCrudScenario<EmployeeSimple>
{
    public MultipleCrudScenario(string connectionString) : base(connectionString)
    { }

    virtual public void DeleteBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        throw new NotImplementedException();
    }

    public void DeleteBatchByKey(IList<int> employeeKeys)
    {
        if (employeeKeys == null || employeeKeys.Count == 0)
            throw new ArgumentException($"{nameof(employeeKeys)} is null or empty.", nameof(employeeKeys));

        throw new NotImplementedException();
    }

    public IList<EmployeeSimple> FindByLastName(string lastName)
    {
        throw new NotImplementedException();
    }

    virtual public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        throw new NotImplementedException();
    }

    public IList<int> InsertBatchReturnKeys(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        throw new NotImplementedException();
    }

    public IList<EmployeeSimple> InsertBatchReturnRows(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        throw new NotImplementedException();
    }

    public void InsertBatchWithRefresh(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        throw new NotImplementedException();
    }

    virtual public void UpdateBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        throw new NotImplementedException();
    }
}