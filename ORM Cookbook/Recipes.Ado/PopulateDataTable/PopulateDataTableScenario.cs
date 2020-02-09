using Microsoft.Data.SqlClient;
using Recipes.PopulateDataTable;
using System.Data;

namespace Recipes.Ado.PopulateDataTable
{
    public class PopulateDataTableScenario : SqlServerScenarioBase, IPopulateDataTableScenario
    {
        public PopulateDataTableScenario(string connectionString) : base(connectionString)
        { }

        public DataTable FindByFlags(bool isExempt, bool isEmployee)
        {
            const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec WHERE ec.IsExempt = @IsExempt AND ec.IsEmployee = @IsEmployee;";

            var result = new DataTable();

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@IsExempt", isExempt);
                cmd.Parameters.AddWithValue("@IsEmployee", isEmployee);
                using (var reader = cmd.ExecuteReader())
                    result.Load(reader);
            }
            return result;
        }

        public DataTable GetAll()
        {
            const string sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec;";

            var result = new DataTable();

            using (var con = OpenConnection())
            using (var cmd = new SqlCommand(sql, con))
            using (var reader = cmd.ExecuteReader())
                result.Load(reader);

            return result;
        }
    }
}
