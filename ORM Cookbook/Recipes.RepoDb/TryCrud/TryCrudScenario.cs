using Recipes.RepoDB.Models;
using Recipes.TryCrud;
using RepoDb.Enumerations;
using System.Data;

namespace Recipes.RepoDB.TryCrud;

public class TryCrudScenario : ITryCrudScenario<EmployeeClassification>
{
    readonly string m_ConnectionString;

    public TryCrudScenario(string connectionString)
    {
        m_ConnectionString = connectionString;
    }

    public int Create(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
            return repository.Insert<int>(classification);
    }

    public void DeleteByKeyOrException(int employeeClassificationKey)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        {
            var rowCount = repository.Delete(employeeClassificationKey);
            if (rowCount != 1)
                throw new DataException($"No row was found for key {employeeClassificationKey}.");
        }
    }

    public bool DeleteByKeyWithStatus(int employeeClassificationKey)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
            return 1 == repository.Delete(employeeClassificationKey);
    }

    public void DeleteOrException(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        {
            var rowCount = repository.Delete(classification);
            if (rowCount != 1)
                throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
        }
    }

    public bool DeleteWithStatus(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
            return 1 == repository.Delete(classification);
    }

    public EmployeeClassification FindByNameOrException(string employeeClassificationName)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        {
            var entity = repository.Query(e => e.EmployeeClassificationName == employeeClassificationName).FirstOrDefault();
            if (null == entity)
                throw new DataException($"Message");

            return entity;
        }
    }

    public EmployeeClassification? FindByNameOrNull(string employeeClassificationName)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
            return repository.Query(e => e.EmployeeClassificationName == employeeClassificationName).FirstOrDefault();
    }

    public EmployeeClassification GetByKeyOrException(int employeeClassificationKey)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        {
            var entity = repository.Query(employeeClassificationKey).FirstOrDefault();
            if (null == entity)
                throw new DataException($"Message");

            return entity;
        }
    }

    public EmployeeClassification? GetByKeyOrNull(int employeeClassificationKey)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
            return repository.Query(employeeClassificationKey).FirstOrDefault();
    }

    public void UpdateOrException(EmployeeClassification classification)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        {
            var rowCount = repository.Update(classification);
            if (rowCount != 1)
                throw new DataException($"Message");
        }
    }

    public bool UpdateWithStatus(EmployeeClassification classification)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
            return 1 == repository.Update(classification);
    }
}