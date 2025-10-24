using Recipes.PopulateDataTable;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Data;

namespace Recipes.ServiceStack.PopulateDataTable;

public class PopulateDataTableScenario : IPopulateDataTableScenario
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public PopulateDataTableScenario(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public DataTable FindByFlags(bool isExempt, bool isEmployee)
    {
        var dt = new DataTable();
        dt.Columns.AddRange(ModelDefinition<EmployeeClassification>.Definition.FieldDefinitions.Select(k =>
            new DataColumn(k.FieldName, k.FieldType)).ToArray());

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            var sql = db.From<EmployeeClassification>().Where(x => x.IsExempt == isExempt && x.IsEmployee == isEmployee);
            foreach (var row in db.SelectLazy(sql))
                dt.Rows.Add(row.Id, row.EmployeeClassificationName, row.IsExempt, row.IsEmployee);
        }

        return dt;
    }

    public DataTable GetAll()
    {
        var dt = new DataTable();
        dt.Columns.AddRange(ModelDefinition<EmployeeClassification>.Definition.FieldDefinitions.Select(k =>
            new DataColumn(k.FieldName, k.FieldType)).ToArray());

        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            foreach (var row in db.SelectLazy(db.From<EmployeeClassification>()))
                dt.Rows.Add(row.Id, row.EmployeeClassificationName, row.IsExempt, row.IsEmployee);
        }

        return dt;
    }
}