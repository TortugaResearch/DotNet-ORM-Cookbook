using Recipes.ModelWithLookup;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.ModelWithLookup;

public class ModelWithLookupSimpleScenario : IModelWithLookupSimpleScenario<Employee>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public ModelWithLookupSimpleScenario(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public int Create(Employee employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
            return (int)db.Insert(employee, true);
    }

    public void Delete(Employee employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.Delete(employee);
    }

    public void DeleteByKey(int employeeKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.DeleteById<Employee>(employeeKey);
    }

    public IList<Employee> FindByLastName(string lastName)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.Select<Employee>(e => e.LastName == lastName);
    }

    public IList<Employee> GetAll()
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.Select<Employee>();
    }

    public Employee? GetByKey(int employeeKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.SingleById<Employee>(employeeKey);
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            return db.SingleById<EmployeeClassification>(employeeClassificationKey);
    }

    public void Update(Employee employee)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
            db.Update(employee);
    }
}