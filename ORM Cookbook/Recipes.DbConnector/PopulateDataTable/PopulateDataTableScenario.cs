using Recipes.PopulateDataTable;
using System.Data;

namespace Recipes.DbConnector.PopulateDataTable;

public class PopulateDataTableScenario : ScenarioBase, IPopulateDataTableScenario
{
    public PopulateDataTableScenario(string connectionString) : base(connectionString)
    {
    }

    public DataTable FindByFlags(bool isExempt, bool isEmployee)
    {
        var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec WHERE ec.IsExempt = @isExempt AND ec.IsEmployee = @isEmployee;";

        return DbConnector.ReadToDataTable(sql, new { isExempt, isEmployee }).Execute();
    }

    public DataTable GetAll()
    {
        var sql = @"SELECT ec.EmployeeClassificationKey, ec.EmployeeClassificationName, ec.IsExempt, ec.IsEmployee FROM HR.EmployeeClassification ec;";

        return DbConnector.ReadToDataTable(sql).Execute();
    }
}
