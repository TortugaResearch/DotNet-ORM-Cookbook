using Dapper;
using Recipes.BasicStoredProc;
using Recipes.Dapper.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Recipes.Dapper.BasicStoredProc
{
    public class BasicStoredProcScenario : ScenarioBase,
        IBasicStoredProcScenario<EmployeeClassification, EmployeeClassificationWithCount>
    {
        public BasicStoredProcScenario(string connectionString) : base(connectionString)
        { }

        public IList<EmployeeClassificationWithCount> CountEmployeesByClassification()
        {
            using (var con = OpenConnection())
                return con.Query<EmployeeClassificationWithCount>("HR.CountEmployeesByClassification",
                    commandType: CommandType.StoredProcedure).ToList();
        }

        public int CreateEmployeeClassification(EmployeeClassification employeeClassification)
        {
            if (employeeClassification == null)
                throw new ArgumentNullException(nameof(employeeClassification),
                    $"{nameof(employeeClassification)} is null.");

            //Need to copy the parameters so we can exclude the unused EmployeeClassificationKey
            using (var con = OpenConnection())
                return con.ExecuteScalar<int>("HR.CreateEmployeeClassification",
                    new
                    {
                        employeeClassification.EmployeeClassificationName,
                        employeeClassification.IsEmployee,
                        employeeClassification.IsExempt
                    }, commandType: CommandType.StoredProcedure);
        }

        public IList<EmployeeClassification> GetEmployeeClassifications()
        {
            using (var con = OpenConnection())
                return con.Query<EmployeeClassification>("HR.GetEmployeeClassifications",
                    commandType: CommandType.StoredProcedure).ToList();
        }

        public EmployeeClassification? GetEmployeeClassifications(int employeeClassificationKey)
        {
            using (var con = OpenConnection())
                return con.Query<EmployeeClassification>("HR.GetEmployeeClassifications",
                    new { employeeClassificationKey }, commandType: CommandType.StoredProcedure).SingleOrDefault();
        }
    }
}
