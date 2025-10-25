using Recipes.MultipleCrud;
using Recipes.RepoDB.Models;
using RepoDb.Extensions;

using RepoDb.Enumerations;

namespace Recipes.RepoDB.MultipleCrud;

public class MultipleCrudScenario : IMultipleCrudScenario<EmployeeSimple>
{
    private readonly string m_ConnectionString;

    public MultipleCrudScenario(string connectionString)
    {
        m_ConnectionString = connectionString;
    }

    public void DeleteBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
        {
            var keys = employees.Select(e => e.EmployeeKey).AsList();
            repository.Delete(e => keys.Contains(e.EmployeeKey));
        }
    }

    public void DeleteBatchByKey(IList<int> employeeKeys)
    {
        if (employeeKeys == null || employeeKeys.Count == 0)
            throw new ArgumentException($"{nameof(employeeKeys)} is null or empty.", nameof(employeeKeys));

        using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
            repository.Delete(e => employeeKeys.Contains(e.EmployeeKey));
    }

    public IList<EmployeeSimple> FindByLastName(string lastName)
    {
        using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
            return repository.Query(e => e.LastName == lastName).AsList();
    }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
            repository.InsertAll(employees);
    }

    public IList<int> InsertBatchReturnKeys(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
            repository.InsertAll(employees);

        return employees.Select(e => e.EmployeeKey).AsList();
    }

    public IList<EmployeeSimple> InsertBatchReturnRows(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
            repository.InsertAll(employees);

        return employees;
    }

    public void InsertBatchWithRefresh(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
            repository.InsertAll(employees);
    }

    public void UpdateBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var repository = new EmployeeSimpleRepository(m_ConnectionString, ConnectionPersistency.Instance))
            repository.UpdateAll(employees);
    }
}