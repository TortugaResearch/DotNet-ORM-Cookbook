using Microsoft.Data.SqlClient;
using Recipes.BulkInsert;
using Recipes.RepoDB.Models;
using RepoDb;
using System.Data;

using RepoDb.Enumerations;

namespace Recipes.RepoDB.BulkInsert;

public class BulkInsertScenario : IBulkInsertScenario<EmployeeSimple>
{
    readonly string m_ConnectionString;

    public BulkInsertScenario(string connectionString)
    {
        m_ConnectionString = connectionString;
    }

    public int CountByLastName(string lastName)
    {
        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        return (int)repository.Count<EmployeeSimple>(e => e.LastName == lastName);
    }

    public void BulkInsert(IList<EmployeeSimple> employees)
    {
        if (employees == null || employees.Count == 0)
            throw new ArgumentException($"{nameof(employees)} is null or empty.", nameof(employees));

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        repository.BulkInsert(employees);
    }

    public void BulkInsert(DataTable employees)
    {
        if (employees == null)
            throw new ArgumentNullException(nameof(employees), $"{nameof(employees)} is null.");

        using (var repository = new DbRepository<SqlConnection>(m_ConnectionString, ConnectionPersistency.Instance))
        repository.BulkInsert<EmployeeSimple>(employees, rowState: DataRowState.Added);
    }
}