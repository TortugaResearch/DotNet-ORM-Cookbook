using System.Collections.Generic;
using Recipes.ModelWithChildren;

namespace LLBLGenPro.OrmCookbook.EntityClasses
{
	public partial class ProductLineEntity
	{
		ICollection<ProductEntity> IProductLine<ProductEntity>.Products
		{
			get { return this.Products; }
		}
	}
}