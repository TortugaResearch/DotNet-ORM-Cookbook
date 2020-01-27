using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.FactoryClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using Recipes.PopulateDataTable;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;
using System.Data;

namespace Recipes.LLBLGenPro.PopulateDataTable
{
    public class PopulateDataTableScenario : IPopulateDataTableScenario
    {
        public DataTable FindByFlags(bool isExempt, bool isEmployee)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var q = new QueryFactory().EmployeeClassification
										  .Where(EmployeeClassificationFields.IsEmployee.Equal(isEmployee)
												 .And(EmployeeClassificationFields.IsExempt.Equal(isExempt)))
                                          .Select(Projection.Full);
                return adapter.FetchAsDataTable(q);
            }
        }

        public DataTable GetAll()
        {
            using (var adapter = new DataAccessAdapter())
            {
                return adapter.FetchAsDataTable(new QueryFactory().EmployeeClassification.Select(Projection.Full));
            }
        }
    }
}
