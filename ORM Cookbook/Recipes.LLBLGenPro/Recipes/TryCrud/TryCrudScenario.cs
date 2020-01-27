using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using Recipes.TryCrud;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using System;
using System.Data;
using System.Linq;

namespace Recipes.LLBLGenPro.TryCrud
{
    public class TryCrudScenario : ITryCrudScenario<EmployeeClassificationEntity>
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

        public void DeleteByKeyOrException(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                // delete directly
                int count = adapter.DeleteEntitiesDirectly(typeof(EmployeeClassificationEntity),
                                               new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey
																									   .Equal(employeeClassificationKey)));
                if (count <= 0)
                {
                    throw new DataException($"No row was found for key {employeeClassificationKey}.");
                }
            }
        }

        public bool DeleteByKeyWithStatus(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                // delete directly
                int count = adapter.DeleteEntitiesDirectly(typeof(EmployeeClassificationEntity),
                                                           new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey
																												   .Equal(employeeClassificationKey)));
                return count > 0;
            }
        }

        public void DeleteOrException(EmployeeClassificationEntity classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                classification.IsNew = false;
                if (!adapter.DeleteEntity(classification))
                {
                    throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
                }
            }
        }

        public bool DeleteWithStatus(EmployeeClassificationEntity classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                classification.IsNew = false;
                return adapter.DeleteEntity(classification);
            }
        }

        public EmployeeClassificationEntity FindByNameOrException(string employeeClassificationName)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).EmployeeClassification
												.Single(ec => ec.EmployeeClassificationName == employeeClassificationName);
            }
        }

        public EmployeeClassificationEntity? FindByNameOrNull(string employeeClassificationName)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).EmployeeClassification
												.SingleOrDefault(ec => ec.EmployeeClassificationName == employeeClassificationName);
            }
        }

        public EmployeeClassificationEntity GetByKeyOrException(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var ec = adapter.FetchNewEntity<EmployeeClassificationEntity>(
													new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey
																											.Equal(employeeClassificationKey)));
                if (ec.IsNew)
                {
                    throw new DataException($"No row was found for key {employeeClassificationKey}.");
                }
                return ec;
            }
        }

        public EmployeeClassificationEntity? GetByKeyOrNull(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var ec = adapter.FetchNewEntity<EmployeeClassificationEntity>(
													new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey
																											.Equal(employeeClassificationKey)));
                return ec.IsNew ? null : ec;
            }
        }

        public void UpdateOrException(EmployeeClassificationEntity classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                var toPersist = adapter.FetchNewEntity<EmployeeClassificationEntity>(
													new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey
																											.Equal(classification.EmployeeClassificationKey)));
                if (!toPersist.IsNew)
                {
                    toPersist.EmployeeClassificationName = classification.EmployeeClassificationName;
                    if (adapter.SaveEntity(toPersist))
                    {
                        // succeeded.
                        return;
                    }
                    // save failed...
                }
                throw new DataException($"No row was found for key {classification.EmployeeClassificationKey}.");
            }
        }

        public bool UpdateWithStatus(EmployeeClassificationEntity classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                var toPersist = adapter.FetchNewEntity<EmployeeClassificationEntity>(
													new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey
																											.Equal(classification.EmployeeClassificationKey)));
                if (!toPersist.IsNew)
                {
                    toPersist.EmployeeClassificationName = classification.EmployeeClassificationName;
                    return adapter.SaveEntity(toPersist, refetchAfterSave: false, recurse: false);
                }
                return false;
            }
        }
    }
}
