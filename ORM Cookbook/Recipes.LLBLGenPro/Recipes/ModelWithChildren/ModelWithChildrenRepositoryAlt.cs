using System;
using LLBLGenPro.OrmCookbook.DatabaseSpecific;
using LLBLGenPro.OrmCookbook.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Recipes.LLBLGenPro.ModelWithChildren
{
	public class ModelWithChildrenRepositoryAlt : ModelWithChildrenRepository
	{
		public override void UpdateGraphWithChildDeletes(ProductLineEntity productLine)
		{
			if(productLine == null)
				throw new ArgumentNullException(nameof(productLine), $"{nameof(productLine)} is null.");

			// this update method will update the related products. Any removed product has to be removed as it's orphaned. 
			// we inserted a removal tracker in the productline entity to track these, so we can just delete them from 
			// this collection. We also have to update the entity and related entities. We'll use a unit of work object
			// for this to have easy transaction management.
			var uow = new UnitOfWork2();
			uow.AddForSave(productLine);
			uow.AddCollectionForDelete(productLine.Products.RemovedEntitiesTracker);
			using (var adapter = new DataAccessAdapter())
			{
				uow.Commit(adapter);
			}
		}

	}
}