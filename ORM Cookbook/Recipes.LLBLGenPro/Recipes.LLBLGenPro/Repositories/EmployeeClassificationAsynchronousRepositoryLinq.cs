using Recipes.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Recipes.LLBLGenPro.Repositories
{
	/// <summary>
	/// Repository implementation which uses the Linq API.
	/// </summary>
	/// <seealso cref="EmployeeClassificationEntity" />
	public class EmployeeClassificationAsynchronousRepositoryLinq : EmployeeClassificationAsynchronousRepositoryBase
    {
		public override async Task<EmployeeClassificationEntity> FindByNameAsync(string employeeClassificationName)
        {
            using (var adapter = new DataAccessAdapter())
            {
	            var metaData = new LinqMetaData(adapter);
				return await metaData.EmployeeClassification.Where(ec => ec.EmployeeClassificationName == employeeClassificationName).SingleOrDefaultAsync();
            }
        }

		public override async Task<IList<EmployeeClassificationEntity>> GetAllAsync()
        {
            using (var adapter = new DataAccessAdapter())
            {
				var metaData = new LinqMetaData(adapter);
				return await metaData.EmployeeClassification.ToListAsync();
            }
        }

        public override async Task<EmployeeClassificationEntity> GetByKeyAsync(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
				var metaData = new LinqMetaData(adapter);
				return await metaData.EmployeeClassification.FirstOrDefaultAsync(e=>e.EmployeeClassificationKey==employeeClassificationKey);
            }
        }
    }
}


