using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using Recipes.Immutable;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;

namespace Recipes.LLBLGenPro.Immutable
{
    public class ImmutableScenario : IImmutableScenario<ReadOnlyEmployeeClassification>
    {
        public int Create(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                var toPersist = classification.ToEntity();
                adapter.SaveEntity(toPersist);
                return toPersist.EmployeeClassificationKey;
            }
        }

        public virtual void Delete(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            DeleteByKey(classification.EmployeeClassificationKey);
        }

        public virtual void DeleteByKey(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(EmployeeClassificationEntity),
                                               new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey
																									   .Equal(employeeClassificationKey)));
            }
        }

        public ReadOnlyEmployeeClassification? FindByName(string employeeClassificationName)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).EmployeeClassification
                                                    .Where(ec => ec.EmployeeClassificationName == employeeClassificationName)
                                                    .Select(x => new ReadOnlyEmployeeClassification(x))
													.SingleOrDefault();
            }
        }

        public IReadOnlyList<ReadOnlyEmployeeClassification> GetAll()
        {
            using (var adapter = new DataAccessAdapter())
            {
                return new LinqMetaData(adapter).EmployeeClassification.Select(x => new ReadOnlyEmployeeClassification(x)).ToImmutableArray();
            }
        }

        public ReadOnlyEmployeeClassification GetByKey(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                var temp = adapter.FetchNewEntity<EmployeeClassificationEntity>(
															new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey
																													.Equal(employeeClassificationKey)));
                if (temp.IsNew)
                    throw new DataException($"No row was found for key {employeeClassificationKey}.");
                return new ReadOnlyEmployeeClassification(temp);
            }
        }

        public void Update(ReadOnlyEmployeeClassification classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                //Get a fresh copy of the row from the database
                var temp = adapter.FetchNewEntity<EmployeeClassificationEntity>(
                                    new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey
																							.Equal(classification.EmployeeClassificationKey)));
                if (!temp.IsNew)
                {
                    //Copy the changed fields
                    temp.EmployeeClassificationName = classification.EmployeeClassificationName;
                    temp.IsEmployee = classification.IsEmployee;
                    temp.IsExempt = classification.IsExempt;
                    adapter.SaveEntity(temp);
                }
            }
        }
    }
}
