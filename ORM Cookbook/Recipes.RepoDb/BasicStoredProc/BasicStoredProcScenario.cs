using Microsoft.Data.SqlClient;
using Recipes.BasicStoredProc;
using Recipes.RepoDB.Models;
using RepoDb;
using RepoDb.Enumerations;
using RepoDb.Extensions;
using System.Data;

namespace Recipes.RepoDB.BasicStoredProc;

public class BasicStoredProcScenario : IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount>
{
    readonly string m_ConnectionString;

    public BasicStoredProcScenario(string connectionString)
    {
        m_ConnectionString = connectionString;
    }

    public IList<EmployeeClassificationWithCount> CountEmployeesByClassification()
    {
        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
            return repository.ExecuteQuery<EmployeeClassificationWithCount>("[HR].[CountEmployeesByClassification]",
                commandType: CommandType.StoredProcedure).AsList();
    }

    public int CreateEmployeeClassification(EmployeeClassification employeeClassification)
    {
        if (employeeClassification == null)
            throw new ArgumentNullException(nameof(employeeClassification),
                $"{nameof(employeeClassification)} is null.");

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance)) return repository.ExecuteScalar<int>("[HR].[CreateEmployeeClassification]", new
        {
            employeeClassification.EmployeeClassificationName,
            employeeClassification.IsExempt,
            employeeClassification.IsEmployee
        }, commandType: CommandType.StoredProcedure);
    }

    public IList<EmployeeClassification> GetEmployeeClassifications()
    {
        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance)) return repository.ExecuteQuery<EmployeeClassification>("[HR].[GetEmployeeClassifications]",
            commandType: CommandType.StoredProcedure).AsList();
    }

    public EmployeeClassification? GetEmployeeClassifications(int employeeClassificationKey)
    {
        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance)) return repository.ExecuteQuery<EmployeeClassification>("[HR].[GetEmployeeClassifications]",
            new { EmployeeClassificationKey = employeeClassificationKey },
            commandType: CommandType.StoredProcedure).FirstOrDefault();
    }
}