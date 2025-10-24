using Recipes.Chain.Models;
using Recipes.MultipleCrud;
using Tortuga.Chain;

namespace Recipes.Chain.MultipleCrud;

public class MultipleCrudScenario : IMultipleCrudScenario<EmployeeSimple>
{
    readonly SqlServerDataSource m_DataSource;

    public MultipleCrudScenario(SqlServerDataSource dataSource)
    {
        m_DataSource = dataSource;
    }

    public void DeleteBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        m_DataSource.DeleteByKeyList<EmployeeSimple>(employees.Select(x => x.EmployeeKey)).Execute();
    }

    public void DeleteBatchByKey(IList<int> employeeKeys)
    {
        if (employeeKeys == null || employeeKeys.Count == 0)
            throw new ArgumentException($"{nameof(employeeKeys)} is null or empty.", nameof(employeeKeys));

        m_DataSource.DeleteByKeyList<EmployeeSimple>(employeeKeys).Execute();
    }

    public IList<EmployeeSimple> FindByLastName(string lastName)
    {
        return m_DataSource.From<EmployeeSimple>(new { lastName }).ToCollection().Execute();
    }

    public void InsertBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        m_DataSource.InsertBatch((IReadOnlyList<EmployeeSimple>)employees).Execute();
    }

    public IList<int> InsertBatchReturnKeys(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        return m_DataSource.InsertBatch((IReadOnlyList<EmployeeSimple>)employees).ToInt32List().Execute();
    }

    public IList<EmployeeSimple> InsertBatchReturnRows(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        return m_DataSource.InsertBatch((IReadOnlyList<EmployeeSimple>)employees).ToCollection<EmployeeSimple>().Execute();
    }

    public void InsertBatchWithRefresh(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        //Chain does not support updating multiple rows at one time from objects
        //Use the WithRefresh() link to update the original object.
        using (var trans = m_DataSource.BeginTransaction())
        {
            foreach (var item in employees)
                trans.Insert(item).WithRefresh().Execute();

            trans.Commit();
        }
    }

    public void UpdateBatch(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        //Chain does not support updating multiple rows at one time from objects
        using (var trans = m_DataSource.BeginTransaction())
        {
            foreach (var item in employees)
                trans.Update(item).Execute();

            trans.Commit();
        }
    }
}