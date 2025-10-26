using Recipes.LargeBatch;
using Recipes.NPoco.Models;

namespace Recipes.NPoco.LargeBatch;

public class LargeBatchScenario : ScenarioBase, ILargeBatchScenario<EmployeeSimple>
{
    public LargeBatchScenario(string connectionString) : base(connectionString)
    { }

    public int CountByLastName(string lastName)
    {
        throw new NotImplementedException();
    }

    public int MaximumBatchSize => 2100 / 7;

    virtual public void InsertLargeBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        throw new NotImplementedException();
    }

    virtual public void InsertLargeBatch(IList<EmployeeSimple> employees, int batchSize)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        throw new NotImplementedException();
    }
}