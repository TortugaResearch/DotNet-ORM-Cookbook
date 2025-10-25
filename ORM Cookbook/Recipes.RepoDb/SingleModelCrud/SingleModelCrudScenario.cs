using Recipes.RepoDB.Models;
using Recipes.SingleModelCrud;
using RepoDb.Enumerations;
using RepoDb.Extensions;

namespace Recipes.RepoDB.SingleModelCrud;

public class SingleModelCrudScenario : ISingleModelCrudScenario<EmployeeClassification>
{
    readonly string m_ConnectionString;

    public SingleModelCrudScenario(string connectionString)
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

    public void Delete(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        repository.Delete(classification);
    }

    public void DeleteByKey(int employeeClassificationKey)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        repository.Delete(employeeClassificationKey);
    }

    public EmployeeClassification? FindByName(string employeeClassificationName)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Query(e => e.EmployeeClassificationName == employeeClassificationName).FirstOrDefault();
    }

    public IList<EmployeeClassification> GetAll()
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.QueryAll().AsList();
    }

    public EmployeeClassification? GetByKey(int employeeClassificationKey)
    {
        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Query(employeeClassificationKey).FirstOrDefault();
    }

    public void Update(EmployeeClassification classification)
    {
        if (classification == null)
            throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

        using (var repository = new EmployeeClassificationRepository(m_ConnectionString, ConnectionPersistency.Instance))
        repository.Update(classification);
    }
}