using System.Collections.Generic;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.Linq;

namespace Recipes.LLBLGenPro.Repositories
{
    /// <summary>
    /// Repository implementation which uses the Linq API.
    /// </summary>
    public class EmployeeClassificationRepositoryLinq : EmployeeClassificationRepositoryBase
    {
        public override EmployeeClassificationEntity FindByName(string employeeClassificationName)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var metaData = new LinqMetaData(adapter);
                return metaData.EmployeeClassification.SingleOrDefault(ec => ec.EmployeeClassificationName == employeeClassificationName);
            }
        }

        public override IList<EmployeeClassificationEntity> GetAll()
        {
            using (var adapter = new DataAccessAdapter())
            {
                var metaData = new LinqMetaData(adapter);
                return metaData.EmployeeClassification.ToList();
            }
        }

        public override EmployeeClassificationEntity GetByKey(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var metaData = new LinqMetaData(adapter);
                return metaData.EmployeeClassification.FirstOrDefault(e=>e.EmployeeClassificationKey==employeeClassificationKey);
            }
        }
    }
}


