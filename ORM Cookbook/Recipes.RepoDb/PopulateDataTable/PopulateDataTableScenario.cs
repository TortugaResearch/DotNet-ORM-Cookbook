using Microsoft.Data.SqlClient;
using Recipes.PopulateDataTable;
using RepoDb;
using System.Data;

namespace Recipes.RepoDb.PopulateDataTable
{
    public class PopulateDataTableScenario : IPopulateDataTableScenario
    {
        readonly string m_ConnectionString;

        public PopulateDataTableScenario(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public DataTable FindByFlags(bool isExempt, bool isEmployee)
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec WHERE ec.IsExempt = @IsExempt AND ec.IsEmployee = @IsEmployee;";
            var table = new DataTable();

            using (var connection = new SqlConnection(m_ConnectionString))
            {
                using (var reader = connection.ExecuteReader(sql, new { isExempt, isEmployee }))
                {
                    table.Load(reader);
                }
            }

            return table;
        }

        public DataTable GetAll()
        {
            var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec;";
            var table = new DataTable();

            using (var connection = new SqlConnection(m_ConnectionString))
            {
                using (var reader = connection.ExecuteReader(sql))
                {
                    table.Load(reader);
                }
            }

            return table;
        }
    }
}
