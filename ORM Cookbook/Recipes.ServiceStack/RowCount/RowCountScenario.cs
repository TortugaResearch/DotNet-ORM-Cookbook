using Recipes.RowCount;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.RowCount;

public class RowCountScenario : IRowCountScenario<Employee>
{
    private IDbConnectionFactory _dbConnectionFactory;

    public RowCountScenario(IDbConnectionFactory dbConnectionFactory)
    {
        this._dbConnectionFactory = dbConnectionFactory;
    }

    public int EmployeeCount(string lastName)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return (int)db.Count<Employee>(e => e.LastName == lastName);
        }
    }

    public int EmployeeCount()
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return (int)db.Count<Employee>();
        }
    }

    public void InsertBatch(IList<Employee> employees)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            db.InsertAll(employees);
        }
    }
}