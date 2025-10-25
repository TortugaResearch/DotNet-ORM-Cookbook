using Microsoft.Data.SqlClient;
using Recipes.Joins;
using Recipes.RepoDB.Models;
using RepoDb;
using RepoDb.Extensions;

using RDB = RepoDb;

namespace Recipes.RepoDB.Joins;

public class JoinsScenario(string connectionString) : IJoinsScenario<EmployeeDetail, EmployeeSimple>
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
        const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.Employee e INNER JOIN HR.EmployeeClassification ec ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey WHERE e.EmployeeClassificationKey = @EmployeeClassificationKey";

        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.ExecuteQuery<EmployeeDetail>(sql, new { employeeClassificationKey }).AsList();
    }

    public IList<EmployeeDetail> FindByLastName(string lastName)
    {
        const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.Employee e INNER JOIN HR.EmployeeClassification ec ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey WHERE e.LastName = @LastName";

        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.ExecuteQuery<EmployeeDetail>(sql, new { lastName }).AsList();
    }

    public EmployeeDetail? GetByEmployeeKey(int employeeKey)
    {
        const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.Employee e INNER JOIN HR.EmployeeClassification ec ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey WHERE e.EmployeeKey = @EmployeeKey";

        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.ExecuteQuery<EmployeeDetail>(sql, new { employeeKey }).FirstOrDefault();
    }

    public IEmployeeClassification? GetClassification(int employeeClassificationKey)
    {
        const string sql = "SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec WHERE EmployeeClassificationKey = @EmployeeClassificationKey";

        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.ExecuteQuery<EmployeeClassification>(sql, new { employeeClassificationKey }).FirstOrDefault();
    }
}