using Microsoft.Data.SqlClient;
using Recipes.ModelWithLookup;
using Recipes.RepoDB.Models;
using RepoDb;
using RepoDb.Extensions;
using RepoDb.Enumerations;

namespace Recipes.RepoDB.ModelWithLookup;

public class ModelWithLookupSimpleScenario : IModelWithLookupSimpleScenario<EmployeeSimple>
{
    readonly string m_ConnectionString;

    public ModelWithLookupSimpleScenario(string connectionString)
    {
        m_ConnectionString = connectionString;
    }

    public int Create(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Insert<EmployeeSimple, int>(employee);
    }

    public void Delete(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        repository.Delete(employee);
    }

    public void DeleteByKey(int employeeKey)
    {
        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        repository.Delete<EmployeeSimple>(employeeKey);
    }

    public IList<EmployeeSimple> FindByLastName(string lastName)
    {
        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Query<EmployeeSimple>(e => e.LastName == lastName).AsList();
    }

    public IList<EmployeeSimple> GetAll()
    {
        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.QueryAll<EmployeeSimple>().AsList();
    }

    public EmployeeSimple? GetByKey(int employeeKey)
    {
        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Query<EmployeeSimple>(employeeKey).FirstOrDefault();
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        return repository.Query<EmployeeClassification>(employeeClassificationKey).FirstOrDefault();
    }

    public void Update(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        repository.Update(employee);
    }
}