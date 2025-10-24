using Recipes.PartialUpdate;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.PartialUpdate;

public class PartialUpdateScenario : IPartialUpdateScenario<EmployeeClassificationPartial>
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public PartialUpdateScenario(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public int Create(EmployeeClassificationPartial classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return (int)db.Insert(classification, true);
        }
    }

    public EmployeeClassificationPartial? GetByKey(int employeeClassificationKey)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            return db.SingleById<EmployeeClassificationPartial>(employeeClassificationKey);
        }
    }

    public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
    {
        if (updateMessage == null)
            throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            db.Update<EmployeeClassificationPartial>(
                new { updateMessage.EmployeeClassificationName },
                r => r.Id == updateMessage.EmployeeClassificationKey);
        }
    }

    public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
    {
        if (updateMessage == null)
            throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            db.Update<EmployeeClassificationPartial>(
                new { updateMessage.IsEmployee, updateMessage.IsExempt },
                r => r.Id == updateMessage.EmployeeClassificationKey);
        }
    }

    public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            db.Update<EmployeeClassificationPartial>(
                new { isExempt, isEmployee },
                r => r.Id == employeeClassificationKey);
        }
    }
}