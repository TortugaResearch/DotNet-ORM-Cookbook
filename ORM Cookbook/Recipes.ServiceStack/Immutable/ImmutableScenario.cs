using Recipes.Immutable;
using Recipes.ServiceStack.Entities;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Collections.Immutable;

namespace Recipes.ServiceStack.Immutable;

public class ImmutableScenario : IImmutableScenario<ReadOnlyEmployeeClassification>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public ImmutableScenario(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public int Create(ReadOnlyEmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return (int)db.Insert(new EmployeeClassification().PopulateWith(classification), true);
        }
    }

    public void Delete(ReadOnlyEmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            var deleted = db.Delete<EmployeeClassification>(r => r.Id == classification.Id);
            if (deleted != 1)
                throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
        }
    }

    public void DeleteByKey(int employeeClassificationKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            var deleted = db.Delete<EmployeeClassification>(r => r.Id == employeeClassificationKey);
            if (deleted != 1)
                throw new DataException($"No row was found for key {employeeClassificationKey}.");
        }
    }

    public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            var temp = db.Single<EmployeeClassification>(r =>
                r.EmployeeClassificationName == employeeClassificationName);
            return temp == null ? null : new ReadOnlyEmployeeClassification(temp);
        }
    }

    public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return db.Select<EmployeeClassification>()
                .Select(x => new ReadOnlyEmployeeClassification(x))
                .ToImmutableArray();
        }
    }

    public ReadOnlyEmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            var temp = db.Single<EmployeeClassification>(r =>
                r.Id == employeeClassificationKey);
            if (temp == null)
                throw new DataException($"No row was found for key {employeeClassificationKey}.");
            return new ReadOnlyEmployeeClassification(temp);
        }
    }

    public void Update(ReadOnlyEmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            db.Update<EmployeeClassification>(new
            {
                classification.IsEmployee,
                classification.IsExempt,
                classification.EmployeeClassificationName
            }, r => r.Id == classification.Id);
        }
    }
}