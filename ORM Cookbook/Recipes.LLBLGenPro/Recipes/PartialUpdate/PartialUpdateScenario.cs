using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.FactoryClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using Recipes.PartialUpdate;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using SD.LLBLGen.Pro.QuerySpec.Adapter;
using System;
using System.Linq;

namespace Recipes.LLBLGenPro.PartialUpdate
{
    public class PartialUpdateScenario : IPartialUpdateScenario<EmployeeClassificationEntity>
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

        public EmployeeClassificationEntity GetByKey(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return adapter.FetchFirst(new QueryFactory().EmployeeClassification
															.Where(EmployeeClassificationFields.EmployeeClassificationKey
																							   .Equal(employeeClassificationKey)));
            }
        }

        public void UpdateWithObject(EmployeeClassificationNameUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                // use an entity
                var temp = adapter.FetchFirst(new QueryFactory().EmployeeClassification
																.Where(EmployeeClassificationFields.EmployeeClassificationKey
																								   .Equal(updateMessage.EmployeeClassificationKey)));
                if (temp != null)
                {
                    temp.EmployeeClassificationName = updateMessage.EmployeeClassificationName;
                    adapter.SaveEntity(temp);
                }
            }
        }

        public void UpdateWithObject(EmployeeClassificationFlagsUpdater updateMessage)
        {
            if (updateMessage == null)
                throw new ArgumentNullException(nameof(updateMessage), $"{nameof(updateMessage)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                // for kicks, update the entity directly in the DB, without fetching one first.
                var updater = new EmployeeClassificationEntity();
                updater.IsEmployee = updateMessage.IsEmployee;
                updater.IsExempt = updateMessage.IsExempt;
                adapter.UpdateEntitiesDirectly(updater, 
											   new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey
																									   .Equal(updateMessage.EmployeeClassificationKey)));
            }
        }

        public void UpdateWithSeparateParameters(int employeeClassificationKey, bool isExempt, bool isEmployee)
        {
            using (var adapter = new DataAccessAdapter())
            {
                // let's use Linq for a change...
                var temp = new LinqMetaData(adapter).EmployeeClassification.FirstOrDefault(ec => ec.EmployeeClassificationKey == employeeClassificationKey);
                if (temp != null)
                {
                    //Copy the changed fields
                    temp.IsExempt = isExempt;
                    temp.IsEmployee = isEmployee;
                    adapter.SaveEntity(temp);
                }
            }
        }
    }
}
