using Recipes.Xpo.Entities;
using Recipes.PopulateDataTable;
using System.Data;
using System.Linq;
using DevExpress.Xpo;

namespace Recipes.Xpo.PopulateDataTable
{
    public class PopulateDataTableScenario : IPopulateDataTableScenario
    {

        public DataTable FindByFlags(bool isExempt, bool isEmployee)
        {
            var dt = new DataTable();
            dt.Columns.Add("EmployeeClassificationKey", typeof(int));
            dt.Columns.Add("EmployeeClassificationName", typeof(string));
            dt.Columns.Add("IsExempt", typeof(bool));
            dt.Columns.Add("IsEmployee", typeof(bool));

            using (var uow = new UnitOfWork())
            {
                foreach (var row in uow.Query<EmployeeClassification>().Where(x => x.IsExempt == isExempt && x.IsEmployee == isEmployee))
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

            using (var uow = new UnitOfWork())
            {
                foreach (var row in uow.Query<EmployeeClassification>())
                    dt.Rows.Add(row.EmployeeClassificationKey, row.EmployeeClassificationName, row.IsExempt, row.IsEmployee);
            }
            return dt;
        }
    }
}
