using Microsoft.Data.SqlClient;
using Recipes.RepoDB.Models;
using Recipes.Views;
using RepoDb;
using RepoDb.Extensions;

using RDB = RepoDb;

namespace Recipes.RepoDB.Views;

public class ViewsScenario(string connectionString) : IViewsScenario<EmployeeDetail, EmployeeSimple>
{
    public int Create(EmployeeSimple employee)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.Insert<EmployeeSimple, int>(employee);
    }

    public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
    {
        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.Query<EmployeeDetail>(e => e.EmployeeClassificationKey == employeeClassificationKey).AsList();
    }

    public IList<EmployeeDetail> FindByLastName(string lastName)
    {
        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.Query<EmployeeDetail>(e => e.LastName == lastName).AsList();
    }

    public EmployeeDetail? GetByEmployeeKey(int employeeKey)
    {
        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.Query<EmployeeDetail>(e => e.EmployeeKey == employeeKey).FirstOrDefault();
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.Query<EmployeeClassification>(employeeClassificationKey).FirstOrDefault();
    }
}