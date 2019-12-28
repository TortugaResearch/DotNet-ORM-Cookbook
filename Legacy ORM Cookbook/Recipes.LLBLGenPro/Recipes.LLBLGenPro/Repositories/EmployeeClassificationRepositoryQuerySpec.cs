using System.Collections.Generic;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.FactoryClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;

namespace Recipes.LLBLGenPro.Repositories
{
    /// <summary>
    /// Repository implementation which uses the QuerySpec API.
    /// </summary>
    public class EmployeeClassificationRepositoryQuerySpec : EmployeeClassificationRepositoryBase
    {
        public override EmployeeClassificationEntity FindByName(string employeeClassificationName)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var q = new QueryFactory().EmployeeClassification.Where(EmployeeClassificationFields.EmployeeClassificationName.Equal(employeeClassificationName));
                return adapter.FetchSingle(q);
            }
        }

        public override IList<EmployeeClassificationEntity> GetAll()
        {
            using (var adapter = new DataAccessAdapter())
            {
                return (IList<EmployeeClassificationEntity>)adapter.FetchQuery(new QueryFactory().EmployeeClassification);
            }
        }

        public override EmployeeClassificationEntity GetByKey(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var q = new QueryFactory().EmployeeClassification.Where(EmployeeClassificationFields.EmployeeClassificationKey.Equal(employeeClassificationKey));
                return adapter.FetchFirst(q);
            }
        }
    }
}


