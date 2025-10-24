using Recipes.ServiceStack.Entities;
using Recipes.SingleModelCrud;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.SingleModelCrud;

public class SingleModelCrudScenario : ISingleModelCrudScenario<EmployeeClassification>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public SingleModelCrudScenario(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public int Create(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return (int)db.Insert(classification, true);
        }
    }

    public virtual void Delete(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            db.Delete(classification);
        }
    }

    public virtual void DeleteByKey(int employeeClassificationKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            db.DeleteById<EmployeeClassification>(employeeClassificationKey);
        }
    }

    public EmployeeClassification FindByName(string employeeClassificationName)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return db.Single<EmployeeClassification>(
                r => r.EmployeeClassificationName == employeeClassificationName);
        }
    }

    public IList<EmployeeClassification> GetAll()
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return db.Select<EmployeeClassification>();
        }
    }

    public EmployeeClassification GetByKey(int employeeClassificationKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return db.SingleById<EmployeeClassification>(employeeClassificationKey);
        }
    }

    public virtual void Update(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            db.Update(classification);
        }
    }
}