using Recipes.Repositories;
using System.Collections.Generic;
using System.Linq;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Recipes.LLBLGenPro.Repositories
{
    /// <summary>
    /// Base class for the repository. Shared for linq & queryspec
    /// </summary>
    /// <seealso cref="Recipes.Repositories.IEmployeeClassificationRepository{EmployeeClassification}" />
    public abstract class EmployeeClassificationRepositoryBase : IEmployeeClassificationRepository<EmployeeClassificationEntity>
    {
        public int Create(EmployeeClassificationEntity classification)
        {
            using (var adapter = new DataAccessAdapter())
            {
                adapter.SaveEntity(classification, refetchAfterSave: true);
                return classification.EmployeeClassificationKey;
            }
        }

        public void Delete(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                // delete directly from the Database, no need to fetch it first. 
                adapter.DeleteEntitiesDirectly(typeof(EmployeeClassificationEntity),
                                               new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey == employeeClassificationKey));
            }
        }

        public void Delete(EmployeeClassificationEntity classification)
        {
            using (var adapter = new DataAccessAdapter())
            {
                adapter.DeleteEntity(classification);
            }
        }

        public void Update(EmployeeClassificationEntity classification)
        {
            using(var adapter = new DataAccessAdapter())
            {
                // fk's are synced automatically, simply save the graph. Refetches entity as it's used after this call.
                adapter.SaveEntity(classification, refetchAfterSave: true);
            }
        }

        public abstract EmployeeClassificationEntity FindByName(string employeeClassificationName);
        public abstract IList<EmployeeClassificationEntity> GetAll();
        public abstract EmployeeClassificationEntity GetByKey(int employeeClassificationKey);
    }
}


