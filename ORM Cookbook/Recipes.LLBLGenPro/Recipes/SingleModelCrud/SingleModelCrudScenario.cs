using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.FactoryClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using Recipes.SingleModelCrud;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.LLBLGenPro.SingleModelCrud
{
    public class SingleModelCrudScenario : ISingleModelCrudScenario<EmployeeClassificationEntity>
    {
        public int Create(EmployeeClassificationEntity classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                adapter.SaveEntity(classification, true, recurse: false);
                return classification.EmployeeClassificationKey;
            }
        }

        public virtual void Delete(EmployeeClassificationEntity classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                // flag the entity as not-new, so we can delete it without fetching it first if the PK is set.
                classification.IsNew = false;
                adapter.DeleteEntity(classification);
            }
        }

        public virtual void DeleteByKey(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                // delete directly, so we don't have to fetch the entity first.
                adapter.DeleteEntitiesDirectly(typeof(EmployeeClassificationEntity),
                                               new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey
																									   .Equal(employeeClassificationKey)));
            }
        }

        public EmployeeClassificationEntity FindByName(string employeeClassificationName)
        {
            using (var adapter = new DataAccessAdapter())
            {
                // let's use QuerySpec
                return adapter.FetchFirst(new QueryFactory().EmployeeClassification
															.Where(EmployeeClassificationFields.EmployeeClassificationName
																							   .Equal(employeeClassificationName)));
            }
        }

        public IList<EmployeeClassificationEntity> GetAll()
        {
            using (var adapter = new DataAccessAdapter())
            {
                // you know what, let's use the low level API for a change.
                var toReturn = new EntityCollection<EmployeeClassificationEntity>();
                adapter.FetchEntityCollection(toReturn, null);
                return toReturn;
            }
        }

        public EmployeeClassificationEntity? GetByKey(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).EmployeeClassification
												.FirstOrDefault(ec => ec.EmployeeClassificationKey == employeeClassificationKey);
            }
        }

        public virtual void Update(EmployeeClassificationEntity classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                // re-use existing entity (as it tracks changes internally) otherwise fetch the instance from the DB
                EmployeeClassificationEntity toPersist = classification;
                if (classification.IsNew)
                {
                    toPersist = adapter.FetchNewEntity<EmployeeClassificationEntity>(
											new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey
																									.Equal(classification.EmployeeClassificationKey)));
                    toPersist.EmployeeClassificationName = classification.EmployeeClassificationName;
                }
                if (!toPersist.IsNew)
                {
                    adapter.SaveEntity(toPersist, refetchAfterSave: false, recurse: false);
                }
            }
        }
    }
}
