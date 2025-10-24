using Recipes.MultipleCrud;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.MultipleCrud;

public class MultipleCrudScenario : IMultipleCrudScenario<Employee>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public MultipleCrudScenario(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public void DeleteBatch(IList<Employee> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.DeleteAll(employees);
    }

    public void DeleteBatchByKey(IList<int> employeeKeys)
    {
        if (employeeKeys == null || employeeKeys.Count == 0)
            throw new ArgumentException($"{nameof(employeeKeys)} is null or empty.", nameof(employeeKeys));

        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.DeleteByIds<Employee>(employeeKeys);
    }

    public IList<Employee> FindByLastName(string lastName)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.Select<Employee>(e => e.LastName == lastName);
    }

    public void InsertBatch(IList<Employee> employees)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.InsertAll(employees);
    }

    public IList<int> InsertBatchReturnKeys(IList<Employee> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.SaveAll(employees);

        return employees.Select(e => e.Id).ToList();
    }

    public IList<Employee> InsertBatchReturnRows(IList<Employee> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.SaveAll(employees);

        return employees;
    }

    public void InsertBatchWithRefresh(IList<Employee> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.SaveAll(employees);
    }

    public void UpdateBatch(IList<Employee> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.UpdateAll(employees);
    }
}