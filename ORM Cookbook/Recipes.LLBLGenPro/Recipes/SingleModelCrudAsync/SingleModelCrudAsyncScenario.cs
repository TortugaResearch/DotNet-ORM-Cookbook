using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using LLBLGenPro.OrmCookbook.HelperClasses;
using LLBLGenPro.OrmCookbook.Linq;
using Recipes.SingleModelCrudAsync;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.LLBLGenPro.SingleModelCrudAsync
{
    public class SingleModelCrudAsyncScenario : ISingleModelCrudAsyncScenario<EmployeeClassificationEntity>
    {
        public async Task<int> CreateAsync(EmployeeClassificationEntity classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                await adapter.SaveEntityAsync(classification).ConfigureAwait(false);
                return classification.EmployeeClassificationKey;
            }
        }

        public async Task DeleteAsync(EmployeeClassificationEntity classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                classification.IsNew = false;
                await adapter.DeleteEntityAsync(classification).ConfigureAwait(false);
            }
        }

        public async Task DeleteByKeyAsync(int employeeClassificationKey)
        {
            using (var adapter = new DataAccessAdapter())
            {
                await adapter.DeleteEntitiesDirectlyAsync(typeof(EmployeeClassificationEntity),
                                                          new RelationPredicateBucket(EmployeeClassificationFields.EmployeeClassificationKey
																												  .Equal(employeeClassificationKey)))
							 .ConfigureAwait(false);
            }
        }

        public async Task<EmployeeClassificationEntity?> FindByNameAsync(string employeeClassificationName, CancellationToken cancellationToken = default)
        {
            using (var adapter = new DataAccessAdapter())
			{
				return await new LinqMetaData(adapter).EmployeeClassification
													  .Where(ec => ec.EmployeeClassificationName == employeeClassificationName)
													  .SingleOrDefaultAsync(cancellationToken).ConfigureAwait(false);
			}
        }

        public async Task<IList<EmployeeClassificationEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return await new LinqMetaData(adapter).EmployeeClassification.ToListAsync(cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<EmployeeClassificationEntity?> GetByKeyAsync(int employeeClassificationKey, CancellationToken cancellationToken = default)
        {
            using (var adapter = new DataAccessAdapter())
            {
                return await new LinqMetaData(adapter).EmployeeClassification
													  .FirstOrDefaultAsync(ec => ec.EmployeeClassificationKey == employeeClassificationKey, cancellationToken)
													  .ConfigureAwait(false);
            }
        }

        public async Task UpdateAsync(EmployeeClassificationEntity classification)
        {
            if (classification == null)
                throw new ArgumentNullException(nameof(classification), $"{nameof(classification)} is null.");

            using (var adapter = new DataAccessAdapter())
            {
                EmployeeClassificationEntity toPersist = classification;
                if (classification.IsNew)
                {
                    toPersist = await new LinqMetaData(adapter).EmployeeClassification
														 .FirstOrDefaultAsync(ec => ec.EmployeeClassificationKey == classification.EmployeeClassificationKey)
														 .ConfigureAwait(false);
                    if (toPersist != null)
                    {
                        toPersist.EmployeeClassificationName = classification.EmployeeClassificationName;
                    }
                }
                if (toPersist != null && !toPersist.IsNew)
                {
                    await adapter.SaveEntityAsync(toPersist, refetchAfterSave: false, recurse: false).ConfigureAwait(false);
                }
            }
        }
    }
}
