using Microsoft.Data.SqlClient;
using Recipes.BasicStoredProc;
using Recipes.RepoDB.Models;
using RepoDb;
using RepoDb.Extensions;
using System.Data;

using RDB = RepoDb;

namespace Recipes.RepoDB.BasicStoredProc;

public class BasicStoredProcScenario(string connectionString) : IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount>
{
    public IList<EmployeeClassificationWithCount> CountEmployeesByClassification()
    {
        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);

        return repository.ExecuteQuery<EmployeeClassificationWithCount>("[HR].[CountEmployeesByClassification]",
            commandType: CommandType.StoredProcedure).AsList();
    }

    public int CreateEmployeeClassification(EmployeeClassification employeeClassification)
    {
        if (employeeClassification == null)
            throw new ArgumentNullException(nameof(employeeClassification),
                $"{nameof(employeeClassification)} is null.");

        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);
        return repository.ExecuteScalar<int>("[HR].[CreateEmployeeClassification]", new
        {
            employeeClassification.EmployeeClassificationName,
            employeeClassification.IsExempt,
            employeeClassification.IsEmployee
        }, commandType: CommandType.StoredProcedure);
    }

    public IList<EmployeeClassification> GetEmployeeClassifications()
    {
        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);
        return repository.ExecuteQuery<EmployeeClassification>("[HR].[GetEmployeeClassifications]",
            commandType: CommandType.StoredProcedure).AsList();
    }

    public EmployeeClassification? GetEmployeeClassifications(int employeeClassificationKey)
    {
        using var repository = new DbRepository<SqlConnection>(connectionString, RDB.Enumerations.ConnectionPersistency.Instance);
        return repository.ExecuteQuery<EmployeeClassification>("[HR].[GetEmployeeClassifications]",
            new { EmployeeClassificationKey = employeeClassificationKey },
            commandType: CommandType.StoredProcedure).FirstOrDefault();
    }
}