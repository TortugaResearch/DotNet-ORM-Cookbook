using Microsoft.Data.SqlClient;
using Recipes.PartialUpdate;
using Recipes.RepoDB.Models;
using RepoDb;
using RepoDb.Enumerations;

using RDB = RepoDb;

namespace Recipes.RepoDB.PartialUpdate;

public class PartialUpdateScenario(string connectionString) : IPartialUpdateScenario<EmployeeClassification>
{
    public int Create(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using var repository = new EmployeeClassificationRepository(connectionString, ConnectionPersistency.Instance);

        return repository.Insert<int>(classification);
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        using var repository = new EmployeeClassificationRepository(connectionString, ConnectionPersistency.Instance);

        return repository.Query(employeeClassificationKey).FirstOrDefault();
    }

    public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
    {
        if (updateMessage == null)
            throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

        using var repository = new EmployeeClassificationRepository(connectionString, ConnectionPersistency.Instance);

        using (var connection = repository.CreateConnection(true))
        {
            connection.Update(ClassMappedNameCache.Get<EmployeeClassification>(), updateMessage);
        }
    }

    public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
    {
        if (updateMessage == null)
            throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

        using var repository = new EmployeeClassificationRepository(connectionString, ConnectionPersistency.Instance);

        using (var connection = repository.CreateConnection(true))
        {
            connection.Update(ClassMappedNameCache.Get<EmployeeClassification>(), updateMessage);
        }
    }

    public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
    {
        using var repository = new EmployeeClassificationRepository(connectionString, ConnectionPersistency.Instance);

        using (var connection = repository.CreateConnection(true))
        {
            connection.Update(ClassMappedNameCache.Get<EmployeeClassification>(),
                new { employeeClassificationKey, isExempt, isEmployee });
        }
    }
}