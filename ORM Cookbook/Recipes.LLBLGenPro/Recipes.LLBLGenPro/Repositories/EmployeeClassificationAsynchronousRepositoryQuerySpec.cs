using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.FactoryClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Recipes.LLBLGenPro.Repositories
{
	/// <summary>
	/// Repository implementation which uses the QuerySpec API.
	/// </summary>
	public class EmployeeClassificationAsynchronousRepositoryQuerySpec : EmployeeClassificationAsynchronousRepositoryBase
	{ 
        public override async Task<EmployeeClassificationEntity> FindByNameAsync(string employeeClassificationName)
        {
            using (var adapter = new DataAccessAdapter())
            {
	            var q = new QueryFactory().EmployeeClassification
										  .Where(EmployeeClassificationFields.EmployeeClassificationName.Equal(employeeClassificationName));
	            return await adapter.FetchSingleAsync(q);
            }
        }

		public override async Task<IList<EmployeeClassificationEntity>> GetAllAsync()
        {
            using (var adapter = new DataAccessAdapter())
            {
	            var toReturn = await adapter.FetchQueryAsync(new QueryFactory().EmployeeClassification);
	            return (IList<EmployeeClassificationEntity>)toReturn;
            }
        }

		public override async Task<EmployeeClassificationEntity> GetByKeyAsync(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
	            var q = new QueryFactory().EmployeeClassification
												.Where(EmployeeClassificationFields.EmployeeClassificationKey.Equal(employeeClassificationKey));
	            return await adapter.FetchFirstAsync(q);
            }
		}
    }
}


