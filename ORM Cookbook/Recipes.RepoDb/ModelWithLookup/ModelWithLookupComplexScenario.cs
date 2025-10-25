using Microsoft.Data.SqlClient;
using Recipes.ModelWithLookup;
using Recipes.RepoDb.Models;
using Recipes.RepoDB.Models;
using RepoDb;
using RepoDb.Extensions;

using RDB = RepoDb;

namespace Recipes.RepoDB.ModelWithLookup;

public class ModelWithLookupComplexScenario(string connectionString) : IModelWithLookupComplexScenario<EmployeeComplex>
{
    public int Create(EmployeeComplex employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
        if (employee.EmployeeClassification == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassification)} is null.");

        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.Insert<EmployeeComplex, int>(employee);
    }

    public void Delete(EmployeeComplex employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        repository.Delete(employee);
    }

    public void DeleteByKey(int employeeKey)
    {
        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        repository.Delete<EmployeeComplex>(employeeKey);
    }

    public IList<EmployeeComplex> FindByLastName(string lastName)
    {
        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.Query<EmployeeComplex>(e => e.LastName == lastName).AsList();
    }

    public IList<EmployeeComplex> GetAll()
    {
        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.QueryAll<EmployeeComplex>().AsList();
    }

    public EmployeeComplex? GetByKey(int employeeKey)
    {
        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        var employee = repository.Query<EmployeeComplex>(employeeKey).FirstOrDefault();
        if (employee != null)
        {
            employee.EmployeeClassification = repository.Query<EmployeeClassification>(employee.EmployeeClassificationKey).FirstOrDefault();
        }
        return employee;
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.Query<EmployeeClassification>(employeeClassificationKey).FirstOrDefault();
    }

    public void Update(EmployeeComplex employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");
        if (employee.EmployeeClassification == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee.EmployeeClassification)} is null.");

        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        repository.Update(employee);
    }
}