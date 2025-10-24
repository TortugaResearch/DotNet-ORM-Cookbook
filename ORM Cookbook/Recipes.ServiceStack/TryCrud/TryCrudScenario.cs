using Recipes.ServiceStack.Entities;
using Recipes.TryCrud;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using DataException = System.Data.DataException;

namespace Recipes.ServiceStack.TryCrud;

public class TryCrudScenario : ITryCrudScenario<EmployeeClassification>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public TryCrudScenario(IDbConnectionFactory dbConnectionFactory)
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

    public void DeleteByKeyOrException(int employeeClassificationKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            var deleted = db.DeleteById<EmployeeClassification>(employeeClassificationKey);
            if (deleted != 1)
                throw new DataException($"No row was found for key {employeeClassificationKey}.");
        }
    }

    public bool DeleteByKeyWithStatus(int employeeClassificationKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return db.DeleteById<EmployeeClassification>(employeeClassificationKey) == 1;
        }
    }

    public void DeleteOrException(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            var deleted = db.DeleteById<EmployeeClassification>(classification.Id);
            if (deleted != 1)
                throw new DataException($"No row was found for key {classification.Id}.");
        }
    }

    public bool DeleteWithStatus(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return db.DeleteById<EmployeeClassification>(classification.Id) == 1;
        }
    }

    public EmployeeClassification FindByNameOrException(string employeeClassificationName)
    {
        EmployeeClassification? record = null;
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            record = db.Single<EmployeeClassification>(
                r => r.EmployeeClassificationName == employeeClassificationName);
        }

        if (record == null)
            throw new DataException($"No row was found with name {employeeClassificationName}.");
        return record;
    }

    public EmployeeClassification? FindByNameOrNull(string employeeClassificationName)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return db.Single<EmployeeClassification>(
                r => r.EmployeeClassificationName == employeeClassificationName);
        }
    }

    public EmployeeClassification GetByKeyOrException(int employeeClassificationKey)
    {
        EmployeeClassification? record = null;
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            record = db.SingleById<EmployeeClassification>(employeeClassificationKey);
        }

        if (record == null)
            throw new DataException($"No row was found for key {employeeClassificationKey}.");
        return record;
    }

    public EmployeeClassification? GetByKeyOrNull(int employeeClassificationKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return db.SingleById<EmployeeClassification>(employeeClassificationKey);
        }
    }

    public void UpdateOrException(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            var updated = db.Update(classification);
            if (updated != 1)
                throw new DataException($"No row was found for key {classification.Id}.");
        }
    }

    public bool UpdateWithStatus(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return db.Update(classification) == 1;
        }
    }
}