using Recipes.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Recipes.LLBLGenPro.Repositories
{
    /// <summary>
    /// Base class for the repository. Shared for linq & queryspec
    /// </summary>
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
                // fk's are synced automatically, simply save the graph. Refetches entity as it's used after this call.
                await adapter.SaveEntityAsync(classification, refetchAfterSave: true);
            }
        }
        
        public abstract Task<EmployeeClassificationEntity> FindByNameAsync(string employeeClassificationName);
        public abstract Task<IList<EmployeeClassificationEntity>> GetAllAsync();
        public abstract Task<EmployeeClassificationEntity> GetByKeyAsync(int employeeClassificationKey);
    }
}


