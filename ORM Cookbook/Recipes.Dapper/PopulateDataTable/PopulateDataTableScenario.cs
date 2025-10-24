using Dapper;
using Recipes.PopulateDataTable;
using System.Data;

namespace Recipes.Dapper.PopulateDataTable;

public class PopulateDataTableScenario : ScenarioBase, IPopulateDataTableScenario
{
    public PopulateDataTableScenario(string connectionString) : base(connectionString)
    {
    }

    public DataTable FindByFlags(bool isExempt, bool isEmployee)
    {
        var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec WHERE ec.IsExempt = @IsExempt AND ec.IsEmployee = @IsEmployee;";

        var result = new DataTable();

        using (var con = OpenConnection())
        using (var reader = con.ExecuteReader(sql, new { isExempt, isEmployee }))
            result.Load(reader);

        return result;
    }

    public DataTable GetAll()
    {
        var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec;";

        var result = new DataTable();

        using (var con = OpenConnection())
        using (var reader = con.ExecuteReader(sql))
            result.Load(reader);

        return result;
    }
}