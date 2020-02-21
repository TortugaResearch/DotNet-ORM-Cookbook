using Microsoft.Data.SqlClient;
using Recipes.RepoDb.Models;
using Recipes.Joins;
using RDB = RepoDb;
using RepoDb;
using RepoDb.Extensions;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Recipes.RepoDb.Joins
{
    public class JoinsScenario : DbRepository<SqlConnection>,
        IJoinsScenario<EmployeeDetail, EmployeeSimple>
    {
        public JoinsScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public int Create(EmployeeSimple employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), $"{nameof(employee)} is null.");

            return Insert<EmployeeSimple, int>(employee);
        }

        public IList<EmployeeDetail> FindByEmployeeClassificationKey(int employeeClassificationKey)
        {
            const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.Employee e INNER JOIN HR.EmployeeClassification ec ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey WHERE e.EmployeeClassificationKey = @EmployeeClassificationKey";

            return ExecuteQuery<EmployeeDetail>(sql, new { employeeClassificationKey }).AsList();
        }

        public IList<EmployeeDetail> FindByLastName(string lastName)
        {
            const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.Employee e INNER JOIN HR.EmployeeClassification ec ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey WHERE e.LastName = @LastName";

            return ExecuteQuery<EmployeeDetail>(sql, new { lastName }).AsList();
        }

        public EmployeeDetail? GetByEmployeeKey(int employeeKey)
        {
            const string sql = "SELECT e.EmployeeKey, e.FirstName, e.MiddleName, e.LastName, e.Title, e.OfficePhone, e.CellPhone, e.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.Employee e INNER JOIN HR.EmployeeClassification ec ON e.EmployeeClassificationKey = ec.EmployeeClassificationKey WHERE e.EmployeeKey = @EmployeeKey";

            return ExecuteQuery<EmployeeDetail>(sql, new { employeeKey }).FirstOrDefault();
        }

        public IEmployeeClassification? GetClassification(int employeeClassificationKey)
        {
            const string sql = "SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec WHERE EmployeeClassificationKey = @EmployeeClassificationKey";

            return ExecuteQuery<EmployeeClassification>(sql, new { employeeClassificationKey }).FirstOrDefault();
        }
    }
}
