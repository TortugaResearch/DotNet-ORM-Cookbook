using System.Data;
using Recipes.PopulateDataTable;
using Recipes.ServiceStack.Entities;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace Recipes.ServiceStack.PopulateDataTable;

public class PopulateDataTableScenario2 : IPopulateDataTableScenario
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public PopulateDataTableScenario2(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public DataTable FindByFlags(bool isExempt, bool isEmployee)
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            var sql = db.From<EmployeeClassification>().Where(x => x.IsExempt == isExempt && x.IsEmployee == isEmployee);
            var cmd = db.CreateCommand();
            cmd.CommandText = sql.ToSelectStatement();
            sql.CopyParamsTo(cmd);

            var result = new DataTable();
            using (var reader = cmd.ExecuteReader())
                result.Load(reader);

            return result;
        }
    }

    public DataTable GetAll()
    {
        using (var db = _dbConnectionFactory.OpenDbConnection())
        {
            var cmd = db.CreateCommand();
            cmd.CommandText = db.From<EmployeeClassification>().ToSelectStatement();

            var result = new DataTable();
            using (var reader = cmd.ExecuteReader())
                result.Load(reader);

            return result;
        }
    }
}