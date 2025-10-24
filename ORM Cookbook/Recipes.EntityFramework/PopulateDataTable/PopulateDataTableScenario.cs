using Recipes.EntityFramework.Entities;
using Recipes.PopulateDataTable;
using System.Data;

namespace Recipes.EntityFramework.PopulateDataTable;

public class PopulateDataTableScenario : IPopulateDataTableScenario
{
    private Func<OrmCookbookContext> CreateDbContext;

    public PopulateDataTableScenario(Func<OrmCookbookContext> dBContextFactory)
    {
        CreateDbContext = dBContextFactory;
    }

    public DataTable FindByFlags(bool isExempt, bool isEmployee)
    {
        var dt = new DataTable();
        dt.Columns.Add("EmployeeClassificationKey", typeof(int));
        dt.Columns.Add("EmployeeClassificationName", typeof(string));
        dt.Columns.Add("IsExempt", typeof(bool));
        dt.Columns.Add("IsEmployee", typeof(bool));

        using (var context = CreateDbContext())
        {
            foreach (var row in context.EmployeeClassification.Where(x => x.IsExempt == isExempt && x.IsEmployee == isEmployee))
                dt.Rows.Add(row.EmployeeClassificationKey, row.EmployeeClassificationName, row.IsExempt, row.IsEmployee);
        }
        return dt;
    }

    public DataTable GetAll()
    {
        var dt = new DataTable();
        dt.Columns.Add("EmployeeClassificationKey", typeof(int));
        dt.Columns.Add("EmployeeClassificationName", typeof(string));
        dt.Columns.Add("IsExempt", typeof(bool));
        dt.Columns.Add("IsEmployee", typeof(bool));

        using (var context = CreateDbContext())
        {
            foreach (var row in context.EmployeeClassification)
                dt.Rows.Add(row.EmployeeClassificationKey, row.EmployeeClassificationName, row.IsExempt, row.IsEmployee);
        }
        return dt;
    }
}