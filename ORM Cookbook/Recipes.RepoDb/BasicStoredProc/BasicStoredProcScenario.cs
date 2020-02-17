using Microsoft.Data.SqlClient;
using Recipes.BasicStoredProc;
using Recipes.RepoDb.Models;
using RepoDb;
using RepoDb.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using RDB = RepoDb;

namespace Recipes.RepoDb.BasicStoredProc
{
    public class BasicStoredProcScenario : DbRepository<SqlConnection>,
        IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount>
    {
        public BasicStoredProcScenario(string connectionString)
            : base(connectionString, RDB.Enumerations.ConnectionPersistency.Instance)
        { }

        public IList<EmployeeClassificationWithCount> CountEmployeesByClassification()
        {
            return ExecuteQuery<EmployeeClassificationWithCount>("[HR].[CountEmployeesByClassification]",
                commandType: CommandType.StoredProcedure).AsList();
        }

        public int CreateEmployeeClassification(EmployeeClassification employeeClassification)
        {
            if (employeeClassification == null)
                throw new ArgumentNullException(nameof(employeeClassification),
                    $"{nameof(employeeClassification)} is null.");

            return ExecuteScalar<int>("[HR].[CreateEmployeeClassification]", new
            {
                employeeClassification.EmployeeClassificationName,
                employeeClassification.IsExempt,
                employeeClassification.IsEmployee
            }, commandType: CommandType.StoredProcedure);
        }

        public IList<EmployeeClassification> GetEmployeeClassifications()
        {
            return ExecuteQuery<EmployeeClassification>("[HR].[GetEmployeeClassifications]",
                commandType: CommandType.StoredProcedure).AsList();
        }

        public EmployeeClassification? GetEmployeeClassifications(int employeeClassificationKey)
        {
            return ExecuteQuery<EmployeeClassification>("[HR].[GetEmployeeClassifications]",
                new { EmployeeClassificationKey = employeeClassificationKey },
                commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
    }
}
