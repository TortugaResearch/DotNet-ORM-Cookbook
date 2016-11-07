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
	public abstract class EmployeeClassificationAsynchronousRepositoryBase : IEmployeeClassificationAsynchronousRepository<EmployeeClassificationEntity>
    {
        public async Task<int> CreateAsync(EmployeeClassificationEntity classification)
        {
            using (var adapter = new DataAccessAdapter())
            {
				// Simply save the graph. Refetches entity as it's used after this call.
				await adapter.SaveEntityAsync(classification, refetchAfterSave:true);
                return classification.EmployeeClassificationKey;
            }
        }

        public async Task DeleteAsync(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
				// no need for a fetch, delete entity directly from the DB, using an async method call.
	            await adapter.DeleteEntitiesDirectlyAsync(typeof(EmployeeClassificationEntity),
														  new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey == employeeClassificationKey));
            }
        }

        public async Task DeleteAsync(EmployeeClassificationEntity classification)
        {
            using (var adapter = new DataAccessAdapter())
            {
	            await adapter.DeleteEntityAsync(classification);
            }
        }

		public async Task UpdateAsync(EmployeeClassificationEntity classification)
		{
			using(var adapter = new DataAccessAdapter())
			{
				// update directly, no need for first fetching the entity.
				var updater = new EmployeeClassificationEntity() { EmployeeClassificationName = classification.EmployeeClassificationName };
				await adapter.UpdateEntitiesDirectlyAsync(updater, new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey == classification.EmployeeClassificationKey));
			}
		}
		
		public abstract Task<EmployeeClassificationEntity> FindByNameAsync(string employeeClassificationName);
	    public abstract Task<IList<EmployeeClassificationEntity>> GetAllAsync();
	    public abstract Task<EmployeeClassificationEntity> GetByKeyAsync(int employeeClassificationKey);
    }
}


